using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace AIDE_Core
{
    public partial class Form1 : Form
    {
        

        //private bool readingFromCamera = false;
        private bool detectedFromCamera = false;
        private bool detectedFromSensor = false;
        //private bool keepRunning = true;

        private int timeForTimer = 5000;
        private int timesWithoutDetections;
        private int timesWithoutDetectionsForShutdown = 10;

        private SerialPort serialPortForArduino;

        private string AIDE_ClientUrl = "http://localhost:54321/api/";

        private System.Timers.Timer timer;


        private FilterInfoCollection videoDevices;
        EuclideanColorFiltering filter = new EuclideanColorFiltering();
        Color color = Color.Black;
        //GrayscaleBT709 grayscaleFilter = new GrayscaleBT709();
        BlobCounter blobCounter = new BlobCounter();
        int range = 120;

        public Form1()
        {
            InitializeComponent();

            AIDE_Routine();

            blobCounter.MinWidth = 2;
            blobCounter.MinHeight = 2;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    comboBoxCameras.Items.Add(device.Name);
                }

                comboBoxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                comboBoxCameras.Items.Add("No local capture devices");
                videoDevices = null;
            }

            Bitmap b = new Bitmap(320, 240);
            // Rectangle a = (Rectangle)r;
            Pen pen1 = new Pen(Color.FromArgb(160, 255, 160), 3);
            Graphics g2 = Graphics.FromImage(b);
            pen1 = new Pen(Color.FromArgb(255, 0, 0), 3);
            g2.Clear(Color.White);
            g2.DrawLine(pen1, b.Width / 2, 0, b.Width / 2, b.Width);
            g2.DrawLine(pen1, b.Width, b.Height / 2, 0, b.Height / 2);
        }

        private void AIDE_Routine()
        {
            SetSerial();

            SetTimer();
        }

        private void SetSerial()
        {
            try
            {
                var ports = SerialPort.GetPortNames().ToList();
                if (ports.Any())
                {
                    serialPortForArduino = new SerialPort(ports.FirstOrDefault(), 9600);
                    serialPortForArduino.DataReceived += SerialPortForArduino_DataReceived;
                    serialPortForArduino.Open();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SetTimer()
        {
            timesWithoutDetections = 0;
            timer = new System.Timers.Timer(timeForTimer);
            timer.Elapsed += CheckWhatsUp;
            timer.AutoReset = true;
            timer.Enabled = true;

            timer.Start();
        }

        private void SerialPortForArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
            //detectedFromSensor = serialPortForArduino.ReadExisting();
        }

        private void CheckWhatsUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!(detectedFromSensor || detectedFromCamera))
            {
                timesWithoutDetections++;
                if (timesWithoutDetections >= timesWithoutDetectionsForShutdown)
                {
                    var client = new HttpClient();
                    client.GetAsync($"{AIDE_ClientUrl}power/lock");
                }
            }
            else
                timesWithoutDetections = 0;
        }

        

        private void StopEverythingBoi()
        {
            timer.Stop();
            try
            {
                serialPortForArduino.Close();
            }
            catch { }
            

            //keepRunning = false;
            //readingFromCamera = false;

            videoSourcePlayerOriginal.SignalToStop();
            videoSourcePlayerOriginal.WaitForStop();
            videoSourcePlayerClone.SignalToStop();
            videoSourcePlayerClone.WaitForStop();
            videoSourcePlayerFiltered.SignalToStop();
            videoSourcePlayerFiltered.WaitForStop();
        }

        private void videoSourcePlayerClone_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap objectsImage = null;
            Bitmap mImage = null;
            mImage = (Bitmap)image.Clone();
            filter.CenterColor = new RGB(color);
            filter.Radius = (short)range;

            objectsImage = image;
            filter.ApplyInPlace(objectsImage);

            BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, image.Width, image.Height),
            ImageLockMode.ReadOnly, image.PixelFormat);

            //UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            UnmanagedImage grayImage = Grayscale.CommonAlgorithms.BT709.Apply(new UnmanagedImage(objectsData));

            objectsImage.UnlockBits(objectsData);


            blobCounter.ProcessImage(grayImage);//get rectangles
            Rectangle[] rects = blobCounter.GetObjectsRectangles();//store rects in a varibla

            if (rects.Length > 0)//draw blob rectangles on display
            {

                foreach (Rectangle objectRect in rects)
                {
                    Graphics g = Graphics.FromImage(mImage);
                    using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }

                    g.Dispose();
                }
            }

            image = mImage;
        }

        public void videoSourcePlayerFiltered_NewFrame(object sender, ref Bitmap image)
        {
            Bitmap objectsImage = null;


            // set center colol and radius
            filter.CenterColor = new RGB(color);//Color.FromArgb(color.ToArgb());
            filter.Radius = (short)range;
            // apply the filter
            objectsImage = image;
            filter.ApplyInPlace(image);

            // lock image for further processing
            BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, image.PixelFormat);

            // grayscaling
            //UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            UnmanagedImage grayImage = Grayscale.CommonAlgorithms.BT709.Apply(new UnmanagedImage(objectsData));

            // unlock image
            objectsImage.UnlockBits(objectsData);

            // locate blobs 
            blobCounter.ProcessImage(grayImage);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();

            if (rects.Length > 0)
            {
                detectedFromCamera = true;

                Rectangle objectRect = rects[0];

                // draw rectangle around detected object
                Graphics g = Graphics.FromImage(image);


                using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 5))
                {
                    g.DrawRectangle(pen, objectRect);
                }
                g.Dispose();
            }
            else
            {
                detectedFromCamera = false;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //readingFromCamera = true;

            videoSourcePlayerOriginal.SignalToStop();
            videoSourcePlayerOriginal.WaitForStop();
            videoSourcePlayerClone.SignalToStop();
            videoSourcePlayerClone.WaitForStop();
            videoSourcePlayerFiltered.SignalToStop();
            videoSourcePlayerFiltered.WaitForStop();
            // videoDevices = null;
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameras.SelectedIndex].MonikerString);
            //videoSource.DesiredFrameSize = new Size(320, 240);
            //videoSource.DesiredFrameRate = 12;

            videoSourcePlayerOriginal.VideoSource = videoSource;
            videoSourcePlayerOriginal.Start();
            videoSourcePlayerClone.VideoSource = videoSource;
            videoSourcePlayerClone.Start();
            videoSourcePlayerFiltered.VideoSource = videoSource;
            videoSourcePlayerFiltered.Start();
            //groupBox1.Enabled = false;
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            StopEverythingBoi();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopEverythingBoi();
        }
    }
}
