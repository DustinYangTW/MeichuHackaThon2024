
import * as Leaflet from "leaflet";
import "leaflet-routing-machine";

let map: Leaflet.Map;

// 直接在地圖的dom創建按鈕
function createButton(label: string, container: HTMLElement) {
  const btn = Leaflet.DomUtil.create("button", "", container);
  btn.setAttribute("type", "button");
  btn.innerHTML = label;
  btn.classList.add("bg-cyan-200/50", "rounded-full", "p-2");
  return btn;
}

export const generateMap = (locs: {
  lng: string,
  lat: string
}[], id: string) => {
  const totalLng = locs.reduce((a, b) => a + Number(b.lng), 0);
  const totalLat = locs.reduce((a, b) => a + Number(b.lat), 0);
  // 初始化地圖
  map = Leaflet.map(id, {
    center: [totalLng / locs.length, totalLat / locs.length],
    zoom: 100,
  });

  // todo point myself
  console.log(map.locate());

  // 監聽地圖事件
  map.on("click", function (e) {
    const container = Leaflet.DomUtil.create("div"),
      startBtn = createButton("Start from this location", container),
      destBtn = createButton("Go to this location", container);

    Leaflet.popup().setContent(container).setLatLng(e.latlng).openOn(map);
  });
  // 地圖圖層
  Leaflet.tileLayer(
    "https://maps.googleapis.com/maps/vt?pb=!1m5!1m4!1i{z}!2i{x}!3i{y}!4i256!2m3!1e0!2sm!3i349018013!3m9!2sen-US!3sUS!5e18!12m1!1e47!12m3!1e37!2m1!1ssmartmaps!4e0",
    {
      attribution: "&copy; Powered by Google",
      maxZoom: 19,
    }
  ).addTo(map);
  // 增加地圖上標記圖層的元件
  // const tooltip = Leaflet.marker(
  //   Leaflet.latLng((Number(des.lng) + Number(loc.lng)) / 2, (Number(des.lat) + Number(loc.lat)) / 2)
  // ).addTo(map);
  // 從第一個點開始規劃最短路徑
  Leaflet.Routing.control({
    waypoints: [
      ...locs.map(loc => Leaflet.latLng(Number(loc.lng), Number(loc.lat))),
    ],
  })
    .on("routingstart", function (e) {}) // 也可以監聽事件
    .addTo(map);
}