<script setup lang="ts">
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
onMounted(() => {
  // 初始化地圖
  map = Leaflet.map("map", {
    center: [24.789078616981914, 120.99579550204959],
    zoom: 18,
  });
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
  const tooltip = Leaflet.marker(
    Leaflet.latLng(24.789078616981914, 120.99579550204959)
  ).addTo(map);
  // 從第一個點開始規劃最短路徑
  Leaflet.Routing.control({
    waypoints: [
      Leaflet.latLng(24.794450074754028, 120.98143006198887),
      Leaflet.latLng(24.80451226316478, 120.96562595296604),
      Leaflet.latLng(24.789078616981914, 120.99579550204959),
    ],
  })
    // 也可以監聽事件
    .on("routingstart", function (e) {})
    .addTo(map);
});
</script>

<template>
  <div id="map" class="h-full"></div>
</template>

<style scoped></style>
