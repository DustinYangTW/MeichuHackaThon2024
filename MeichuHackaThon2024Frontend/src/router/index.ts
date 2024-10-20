import { createRouter, createWebHashHistory } from "vue-router";
import HomePage from "../views/HomePage.vue";

const router = createRouter({
  history: createWebHashHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomePage,
    },
    {
      path: "/s",
      name: "PathSelectPage",
      component: () => import("../views/PathSelectPage.vue"),
    },
    {
      path: "/p",
      name: "PathPage",
      component: () => import("../views/PathPage.vue"),
    },
    {
      path: "/r",
      name: "RecommendPage",
      component: () => import("../views/RecommendPage.vue"),
    },
  ],
});

export default router;
