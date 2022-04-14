<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AppCoordinate.aspx.cs" Inherits="Portal.AppCoordinate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btn_Add_Coordinate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="plMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>



    <style>
        /* Always set the map height explicitly to define the size of the div
        * element that contains the map. */
        #map {
            height: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #floating-panel {
            position: absolute;
            top: 10px;
            left: 25%;
            z-index: 5;
            background-color: #fff;
            padding: 5px;
            border: 1px solid #999;
            text-align: center;
            font-family: "Roboto", "sans-serif";
            line-height: 30px;
            padding-left: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="ibox col-lg-6">
            <div class="ibox-title">
                <h5>地圖</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content">

                <div class="form-group  row">
                    <div id="floating-panel">
                        <input id="address" type="text" value="" placeholder="請輸入名稱或地址" />
                        <input id="submit" type="button" value="查詢" />
                    </div>
                    <%-- <div id="map"></div>--%>
                    <div id="map" style="height: 800px; width: 800px;"></div>
                </div>

            </div>
        </div>

        <div class="ibox col-lg-6">

            <telerik:RadAjaxPanel ID="plSearch" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <div class="ibox-title">
                    <h5>地圖座標</h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>
                    </div>
                </div>

                <div class="ibox-content">

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">緯度 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_latitude" runat="server" CssClass="form-control" Width="100%" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">經度 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_longitude" runat="server" CssClass="form-control" Width="100%" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">公尺 :</label>
                        <div class="col-sm-10 col-lg-4 row">
                            <telerik:RadTextBox ID="txt_meter" runat="server" CssClass="form-control" Width="100%" InputType="Number" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-2 col-form-label">說明 :</label>
                        <div class="col-sm-10 col-lg-6 row">
                            <telerik:RadTextBox ID="txt_Note" runat="server" CssClass="form-control" Width="100%" />
                        </div>
                    </div>

                    <div class="hr-line-dashed"></div>
                    <div class="form-group  row">
                        <label class="col-sm-12 col-form-label">


                            <input id="RadButton1" type="button" value="重繪" class="btn btn-primary btn-sm" onclick="RepaintCircles()" />

                            <telerik:RadButton ID="btn_Add_Coordinate" runat="server" Text="新增" CssClass="btn btn-primary btn-sm" OnClick="btn_Save_Coordinate_Click" />

                        </label>
                        <div class="col-sm-12 col-lg-4 row">
                            <telerik:RadLabel ID="lblMsg" runat="server" />
                        </div>
                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </div>
    </div>









    <div class="col-lg-12">
        <div class="ibox">
            <div class="ibox-title">
                <h5>座標</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content">

                <telerik:RadAjaxPanel ID="plMain" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">

                    <telerik:RadListView ID="lvMain" runat="server" RenderMode="Lightweight" Skin=""
                        ItemPlaceholderID="Container"
                        OnItemCommand="lvMain_ItemCommand"
                        OnNeedDataSource="Table_Origin_NeedDataSource">
                        <LayoutTemplate>
                            <table class="footable table table-stripped" data-page-size="10" data-filter="#filter">
                                <thead>
                                    <tr>
                                        <th>緯度\</th>
                                        <th>經度</th>
                                        <th>公尺</th>
                                        <th>說明</th>
                                    </tr>
                                </thead>
                                <tbody id="Container" runat="server">
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="5">
                                            <ul class="pagination float-right"></ul>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class="gradeX">
                                <td><%# Eval("Latitude") %></td>
                                <td><%# Eval("Longitude") %></td>
                                <td><%# Eval("Distance") %></td>
                                <td><%# Eval("Note") %></td>
                                <td>
                                    <telerik:RadButton ID="btn_Delete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("AutoKey") %>' CssClass="btn-white btn btn-xs" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            目前並無任座標資料
                        </EmptyDataTemplate>
                    </telerik:RadListView>


                </telerik:RadAjaxPanel>
            </div>
        </div>
    </div>

    <div class="col-lg-12">
        <div class="ibox">
            <div class="ibox-title">
                <h5>操作</h5>
                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                </div>
            </div>
            <div class="ibox-content">

                <div class="row">
                    <img src="images/reference/map1.jpg" />
                </div>
                <div class="row">
                    <img src="images/reference/map2.jpg" />
                </div>
                <div class="row">
                    <img src="images/reference/map3.jpg" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>

        $(document).ready(function () {
            $('.footable').footable();
        });



        const labels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        let labelIndex = 0;



        var lat, lng;
        var map;
        var places;
        var markers = [];
        var autocomplete;

        function initMap() {
            const map = new google.maps.Map(document.getElementById("map"), {
                zoom: 17,
                center: { lat: 25.016382, lng: 121.298262 },
            });
            const geocoder = new google.maps.Geocoder();
            document.getElementById("submit").addEventListener("click", () => {
                geocodeAddress(geocoder, map);
            });
            map.addListener("click", (e) => {
                map.setZoom(17);
                map.setCenter(e.latLng);
                placeMarkerAndPanTo(e.latLng, map);
            });

            //if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                //var marker = new google.maps.Marker({
                //    position: pos,
                //    icon: 'marker.png',
                //    map: map
                //});
                map.setZoom(17);
                map.setCenter(pos);
                placeMarkerAndPanTo(pos, map);
            });
            //} else {
            // Browser doesn't support Geolocation
            //alert("未允許或遭遇錯誤！");
            //}
        }

        ///地址查詢
        function geocodeAddress(geocoder, resultsMap) {
            const address = document.getElementById("address").value;

            if (address.length <= 0) {
                alert("請輸入名稱或地址")
                return;
            }

            geocoder
                .geocode({ address: address })
                .then(({ results }) => {
                    resultsMap.setCenter(results[0].geometry.location);
                    placeMarkerAndPanTo(results[0].geometry.location, resultsMap);
                })
                .catch((e) =>
                    alert("地理位置查詢未成功的原因如下：" + e)
                );
        }



        ///新增tag標記
        function placeMarkerAndPanTo(latLng, map) {

            AddMarker(latLng, map);
        }


        var circles = [];



        //增加標記
        // Adds a marker to the map.
        function AddMarker(location, map) {


            //刪除既有
            DeleteMarkers();

            const marker = new google.maps.Marker({
                zoom: 17,
                position: location,
                map: map,
            });


            markers.push(marker);

            $("#ctl00_ContentPlaceHolder1_txt_latitude").val(location.lat);
            $("#ctl00_ContentPlaceHolder1_txt_longitude").val(location.lng);
            var radius = Number(GetRadius());

            var cityCircle = new google.maps.Circle({
                strokeColor: '#FF0000',
                strokeOpacity: 0.8,
                strokeWeight: 2,
                fillColor: 'Transparent',
                fillOpacity: 0.35,
                map: map,
                center: location,
                radius: radius
            });

            circles.push(cityCircle);
        }


        // Sets the map on all markers in the array.
        function SetMapOnAll(map) {
            for (let i = 0; i < markers.length; i++) {
                markers[i].setMap(map);
            }

        }

        function removecircle() {
            for (var i = 0; i < circles.length; i++) {
                circles[i].setMap(null);
            }
        }



        // Deletes all markers in the array by removing references to them.
        function DeleteMarkers() {
            ClearMarkers();
            removecircle(null);
            //circle.setMap(null);
            markers = [];
            circles = [];
        }



        // Removes the markers from the map, but keeps them in the array.
        function ClearMarkers() {
            SetMapOnAll(null);
            //SetMapOnAllCircle(null);
        }


        //抓取半徑
        function GetRadius() {

            var Radius = $("#ctl00_ContentPlaceHolder1_txt_meter").val();

            if (Radius == "") {
                Radius = 200;
            }
            return Radius;
        }



        //既有資料畫圈
        function DrawCircles(mlat, mlng, mradius) {


            var mCenter = {
                center: { lat: Number(mlat), lng: Number(mlng) }
            };


            const map = new google.maps.Map(document.getElementById("map"), {
                zoom: 17,
                center: mCenter.center,
            });

            const geocoder = new google.maps.Geocoder();
            document.getElementById("submit").addEventListener("click", () => {
                geocodeAddress(geocoder, map);
            });
            map.addListener("click", (e) => {
                map.setZoom(17);
                map.setCenter(e.latLng);
                placeMarkerAndPanTo(e.latLng, map);
            });

            placeMarkerAndPanTo(mCenter.center, map);
        }


        function RepaintCircles() {

            DeleteMarkers();
            var mlat = $("#ctl00_ContentPlaceHolder1_txt_latitude").val();
            var mlng = $("#ctl00_ContentPlaceHolder1_txt_longitude").val();
            var mradius = $("#ctl00_ContentPlaceHolder1_txt_meter").val();

            DrawCircles(mlat, mlng, mradius);
        }







    </script>





    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC3wPyoJzCNJKosq6UtBIK_RBvgY6a6OT8&callback=initMap&libraries=&v=weekly" type="text/javascript"></script>




    <script src="Templates/Inspinia/js/plugins/footable/footable.all.min.js"></script>

    <script src="https://polyfill.io/v3/polyfill.min.js?features=default"></script>



</asp:Content>

