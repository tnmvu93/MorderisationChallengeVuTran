import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import TaskList from "@/components/TaskList.vue";
import TaskDetail from "@/components/TaskDetail.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "list",
    component: TaskList,
    children: [
      {
        path: "/update/:id",
        name: "update",
        component: TaskDetail,
      },
      {
        path: "/create",
        name: "create",
        component: TaskDetail,
      },
    ],
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
