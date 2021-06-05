import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

//Views
import Vendor from "../views/dictionary/Vendor";
import Overview from '../views/dictionary/Overview';
import AccountSystem from "../views/dictionary/AccountSystem";
import ReceiptPaymentList from "../views/dictionary/ReceiptPaymentList";

const routes = [
  { path: "/", component: Overview },
  { path: "/vendor", component: Vendor },
  { path: "/account-system", component: AccountSystem },
  { path: "/receipt-payment", component: ReceiptPaymentList },
];

const router = new VueRouter({
  mode: 'history',
  routes,
});

export default router;
