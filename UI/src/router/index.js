import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

//Views
import Vendor from "../views/dictionary/Vendor";
import Overview from '../views/dictionary/Overview';

const routes = [
  { path: "/vendor", component: Vendor },
  { path: "/", component: Overview },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
