using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GeneticAlgorithm;
using System.Diagnostics;

namespace UpgradeTSPToUI
{
    public partial class frmMain : Form
    {
        GMapOverlay markersOverlay = new GMapOverlay("markers");
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        private GeocodingProvider gp;
        private int countCity = 0;
        private PointLatLng startPoint;
        private PointLatLng finishPoint;
        private List<PointLatLng> lstPoint = new List<PointLatLng>();
        public static int StartCity = 0;
        public static PointLatLng BeforeCity;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            //Load GMap.Net
            try
            {
                GMapView.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                //GMapView.SetPositionByKeywords("Phố đi bộ Nguyễn Huệ");
                //Add Layout 
                GMapView.Overlays.Add(markersOverlay);
                GMapView.Overlays.Add(routesOverlay);
                GMapView.Overlays.Add(polyOverlay);
                //Set events
                lstPlace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnListViewClickRight);
                //at geographics 
                gp = GMapView.MapProvider as GeocodingProvider;
                //focus
                txtSearch.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can not load Map", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
        
        private void GMapView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double dHorizontal = 0, dVertical = 0;

                dHorizontal = GMapView.FromLocalToLatLng(e.X, e.Y).Lat;
                dVertical = GMapView.FromLocalToLatLng(e.X, e.Y).Lng;
               // MessageBox.Show(dHorizontal + " " + dVertical);
                PointLatLng selectedClick = new PointLatLng(dHorizontal, dVertical);

                GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow;
                //List<Placemark> selectedPlace = null;
                Placemark? place = gp.GetPlacemark(selectedClick, out statusCode);
                if (statusCode == GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    lstPlace.Items.Add(place.Value.Address);
                    GMarkerGoogle marker = new GMarkerGoogle(selectedClick, GMarkerGoogleType.green);
                    marker.ToolTipText = place.Value.Address;
                    marker.ToolTipMode = MarkerTooltipMode.Always;

                    markersOverlay.Markers.Add(marker);                 
                    GMapView.Overlays.Add(markersOverlay);
                    lstPoint.Add(selectedClick);
                    countCity = lstPoint.Count;
                    lblSoDiaDiem.Text = countCity.ToString();
                }
                
            }
            else return;
        }

        private void btnStartRoute_Click(object sender, EventArgs e)
        {
            try
            {
                GDirections ss;
                //routesOverlay.Clear();
                var route = GMapProviders.GoogleMap.GetDirections(out ss, startPoint, finishPoint, false, false, false, false, false);
                GMapRoute resultPath = new GMapRoute(ss.Route, "Route");
                if (resultPath != null)
                {
                    resultPath.Stroke.Color = Color.Green;
                    resultPath.Stroke.Width = 2;
                    routesOverlay.Routes.Add(resultPath);
                    GMapView.Overlays.Add(routesOverlay);
                }
                
                MessageBox.Show("Khoảng cách dự tính là : " + string.Format("{0:00}",((double)ss.DistanceValue/1000).ToString()) + " km");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Mời bạn chọn lại vị trí - không có đường bộ");
            }
        }

        private int a = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode status;
            PointLatLng? point = GMapProviders.GoogleMap.GetPoint(txtSearch.Text, out status);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS || point == null) 
            {
                MessageBox.Show("Can not find location, try another keyword");
            }
            else
            {
                PointLatLng currentPoint = new PointLatLng(point.Value.Lat, point.Value.Lng);
                GMarkerGoogle marker = new GMarkerGoogle(currentPoint, GMarkerGoogleType.green);
                markersOverlay.Markers.Add(marker);
                GMapView.Overlays.Add(markersOverlay);
                GMapView.ZoomAndCenterMarkers(markersOverlay.Id);
                
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode status;
            PointLatLng? point = GMapProviders.GoogleMap.GetPoint(txtSearch.Text, out status);
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS || point == null)
            {
                MessageBox.Show("Can not find location, try another keyword");
            }
            else
            {
                PointLatLng currentPoint = new PointLatLng(point.Value.Lat, point.Value.Lng);
                GMarkerGoogle marker = new GMarkerGoogle(currentPoint, GMarkerGoogleType.green);
                markersOverlay.Markers.Add(marker);
                GMapView.Overlays.Add(markersOverlay);
                GMapView.ZoomAndCenterMarkers(markersOverlay.Id);

                GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow;
                Placemark? place = gp.GetPlacemark(currentPoint, out statusCode);
                if (statusCode == GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    lstPlace.Items.Add(place.Value.Address);
                    marker.ToolTipText = place.Value.Address;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    lstPoint.Add(currentPoint);
                    countCity = lstPoint.Count;
                    lblSoDiaDiem.Text = countCity.ToString();
                }          
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        static int indexSelect = -1;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                indexSelect = lstPlace.FocusedItem.Index;
                if (indexSelect != -1)
                {
                    //remove in list point and list place
                    lstPoint.RemoveAt(indexSelect);
                    lstPlace.Items.RemoveAt(indexSelect);
                    //remove on map 
                    markersOverlay.Markers.RemoveAt(indexSelect);
                    indexSelect = -1;
                    lblSoDiaDiem.Text = (countCity - 1).ToString();
                }
                else
                    return;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thao tác thất bại! ");
            }
        }
        //Region find path
        public double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        public double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        public double CityDistance(int i, int j)
        {
            if (i == j)
                return 0;
            PointLatLng start = lstPoint[i];
            PointLatLng finish = lstPoint[j];
            try
            {
                GDirections ss;
                var route = GMapProviders.GoogleMap.GetDirections(out ss, start, finish, false, false, false, false, false);
                GMapRoute resultPath = new GMapRoute(ss.Route, "Route");
                if (resultPath != null)
                {
                    return resultPath.Distance;
                }
                    
            }
            catch (Exception ex)
            {
                return distance(start.Lat, start.Lng, finish.Lat, finish.Lng, 'K');
            }
            return 0;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {           
            //Find TSP
            try
            {
                //Clear Google Map
                polyOverlay.Clear();
                routesOverlay.Clear();
                lstResultPath.Clear();
                markersOverlay.Markers[StartCity].IsVisible = true;
                if (lstPoint.Count == 0)
                {
                    MessageBox.Show("Chưa nhập địa điểm");
                    return;
                }
                TSP tsp = new TSP(lstPoint.Count, 100, 30, 70, 70, 2);
                List<City> lstCity = new List<City>();
                int count = 0;
                //List City
                foreach (var item in lstPoint)
                {
                    City temp = new City(count, lstPlace.Items[count].Text);
                    count++;
                    lstCity.Add(temp);
                }

                //Matrix Distance
                double[,] value = new double[lstPoint.Count, lstPoint.Count];
                for (int i = 0; i < lstPoint.Count; i++)
                {
                    for (int j = 0; j < lstPoint.Count; j++)
                    {
                        value[i, j] = CityDistance(i, j);
                    }
                }
                //Set matrix and result
                TourManager.DistanceCity = value;
                Tour result = new Tour();
                result = tsp.FindPathInPopulation(lstCity, lstCity[StartCity]);
                List<PointLatLng> lstResult = new List<PointLatLng>();

                foreach (var item in result.GetListCityResult())
                {
                    PointLatLng temp = new PointLatLng(lstPoint[item.GetIndexList()].Lat, lstPoint[item.GetIndexList()].Lng);
                    lstResult.Add(temp);
                }

                //Draw result
                GMap.NET.WindowsForms.GMapPolygon polygon = new GMap.NET.WindowsForms.GMapPolygon(lstResult, "mypolygon");
                polygon.Fill = new SolidBrush(Color.Transparent);
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);

                //Redraw new Start address
                //markersOverlay.Markers[StartCity] = new GMarkerGoogle(lstPoint[StartCity], GMarkerGoogleType.green_big_go);

                foreach(var item in result.GetListCityResult())
                {
                    lstResultPath.Items.Add(lstPlace.Items[item.GetIndexList()].Text);
                }

                GMapView.Overlays.Add(polyOverlay);
                MessageBox.Show("Độ dài đường đi là " + result.GetDistance());
                BeforeCity = lstPoint[StartCity];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thao tác thất bại ");
                return;
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstPlace.FocusedItem.Index;
                if (index == 0)
                    return;
                else
                {
                    //update view
                    int newIndex = index - 1;
                    if (newIndex < 0) return;
                    var temp = lstPlace.Items[index].Text;
                    lstPlace.Items[index].Text = lstPlace.Items[newIndex].Text;
                    lstPlace.Items[newIndex].Text = temp;
                    //update data
                    var tam = lstPoint[index];
                    lstPoint[index] = lstPoint[newIndex];
                    lstPoint[newIndex] = tam;
                    //focus new item
                    lstPlace.Items[index].Selected = false;
                    lstPlace.Items[newIndex].Selected = true;
                    lstPlace.FocusedItem = lstPlace.Items[newIndex];
                    lstPlace.Select();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thao tác thất bại! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstPlace.FocusedItem.Index;
                if (index == lstPlace.Items.Count)
                    return;
                else
                {
                    //update view
                    
                    int newIndex = index + 1;
                    if (newIndex > lstPlace.Items.Count) return;
                    var temp = lstPlace.Items[index].Text;
                    lstPlace.Items[index].Text = lstPlace.Items[newIndex].Text;
                    lstPlace.Items[newIndex].Text = temp;
                    //update data
                    var tam = lstPoint[index];
                    lstPoint[index] = lstPoint[newIndex];
                    lstPoint[newIndex] = tam;
                    //focus new item
                    lstPlace.Items[index].Selected = false;
                    lstPlace.Items[newIndex].Selected = true;
                    lstPlace.FocusedItem = lstPlace.Items[newIndex];
                    lstPlace.Select();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thao tác thất bại! ");
            }
        }
        private void btnPushStart_Click(object sender, EventArgs e)
        {
            int indexSelect = lstPlace.FocusedItem.Index;
            if (lstResultPath.Items.Count == 0) 
            {
                lstResultPath.Items.Add(lstPlace.Items[indexSelect]);
                return;
            }
            else
            {
                MessageBox.Show("Can not push start City, must remove first");
                return;
            }   
        }

        private void lstPlace_Click(object sender, EventArgs e)
        {

        }

        private void OnListViewClickRight(object sender, MouseEventArgs e)
        {
            ListView lstView = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = lstView.GetItemAt(e.X, e.Y);
                if (item!=null)
                {
                    item.Selected = true;
                    ContextMenuStrip MenuAction = new ContextMenuStrip();
                    ToolStripMenuItem menuStart = new ToolStripMenuItem("Chọn đỉnh bắt đầu tìm đường");
                    ToolStripMenuItem menuEnd = new ToolStripMenuItem("Chọn đỉnh kết thúc tìm đường");
                    ToolStripMenuItem menuSelect = new ToolStripMenuItem("Chọn đỉnh bắt đầu hành trình");
                    menuStart.Click += new EventHandler(this.OnClickStartPoint);
                    menuEnd.Click += new EventHandler(this.OnClickEndPoint);
                    menuSelect.Click += new EventHandler(this.OnClickSelectPoint);
                    MenuAction.Items.AddRange(new ToolStripItem[] { menuStart, menuEnd, menuSelect});
                    MenuAction.Show(Cursor.Position);
                }
            }
        }
        GMarkerGoogle marker1;
       
        private void OnClickSelectPoint(object sender, EventArgs e)
        {
            int before = StartCity;
            markersOverlay.Markers[StartCity].IsVisible = true;
            markersOverlay.Markers.Remove(marker1);            
            StartCity = lstPlace.FocusedItem.Index;
            //markersOverlay.Markers[StartCity].IsVisible = false;
            marker1 = new GMarkerGoogle(lstPoint[StartCity], GMarkerGoogleType.green_big_go);
            BeforeCity = lstPoint[StartCity];
            markersOverlay.Markers.Add(marker1);
            
        }
        private void OnClickStartPoint(object sender, EventArgs e)
        {
            int index = lstPlace.FocusedItem.Index;
            txtStart.Text = lstPoint[index].Lat.ToString() + " - " + lstPoint[index].Lng.ToString();
            startPoint = lstPoint[index];
        }
        
        private void OnClickEndPoint(object sender, EventArgs e)
        {
            int index = lstPlace.FocusedItem.Index;
            txtFinish.Text = lstPoint[index].Lat.ToString() + " - " + lstPoint[index].Lng.ToString(); ;
            finishPoint = lstPoint[index];
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            lstPlace.Items.Clear();
            lstPoint.Clear();
            lstResultPath.Items.Clear();
            polyOverlay.Clear();
            markersOverlay.Clear();
            routesOverlay.Clear();
            countCity = 0;
            lblSoDiaDiem.Text = "0";
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }
    }
}
