import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

//Views
import Vendor from "../views/dictionary/Vendor";

const routes = [
  { path: "/vendor", component: Vendor },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
