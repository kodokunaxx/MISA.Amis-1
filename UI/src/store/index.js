import Vue from 'vue'
import Vuex from 'vuex'
import * as data from './data'
import axios from 'axios';

Vue.use(Vuex)

export const store = new Vuex.Store({
  state: {
    API_URL: 'https://localhost:44354/api/v1',
    MODE: 'ADD',
    vendors: [],
    accounts: [],
    RPL: [],
    newVendorCode: null,
    newVoucherNumber: null,
    enableSubmit: true,
    isReadOnly: false,
    isLoading: true,
    isShowMenuDetail: true,
    isShowVendorDialog: false,
    isShowAccountDialog: false,
    isShowRPDialog: false,
    isCustomer: false,
    isOrganization: true,
    isShowConfirmDelete: false,
    isShowConfirmClose: false,
    vendorGroup: data.vendorGroup,
    X: data.X,
    employee: data.employee,
    rule: data.rule,
    receive: data.receive,
    payment: data.payment,
    pageIndex: 1,
    pageSize: 20,
    total: 0,
    totalRPL: 0,
    totalAccount: 0,
    deepLevel: 1,
  },
  getters: {
    getApiUrl: state => state.API_URL,
    getMODE: state => state.MODE,
    getIsLoading: state => state.isLoading,
    getVendors: state => state.vendors,
    getAccounts: state => state.accounts,
    getRPL: state => state.RPL,
    getIsShowMenuDetail: state => state.isShowMenuDetail,
    getIsCustomer: state => state.isCustomer,
    getIsOrganization: state => state.isOrganization,
    getVendorGroup: state => state.vendorGroup,
    getX: state => state.X,
    getEmployee: state => state.employee,
    getRule: state => state.rule,
    getReceive: state => state.receive,
    getPayment: state => state.payment,
    getEnableSubmit: state => state.enableSubmit,
    getIsShowVendorDialog: state => state.isShowVendorDialog,
    getIsShowAccountDialog: state => state.isShowAccountDialog,
    getIsShowRPDialog: state => state.isShowRPDialog,
    getIsReadOnly: state => state.isReadOnly,
    getPageIndex: state => state.pageIndex,
    getPageSize: state => state.pageSize,
    getNewVendorCode: state => state.newVendorCode,
    getNewVoucherNumber: state => state.newVoucherNumber,
    getIsShowConfirmDelete: state => state.isShowConfirmDelete,
    getIsShowConfirmClose: state => state.isShowConfirmClose,
    getTotal: state => state.total,
    getTotalRPL: state => state.totalRPL,
    getTotalAccount: state => state.totalAccount,
    getDeepLevel: state => state.deepLevel,
  },
  mutations: {
    resetState: state => {
      console.log('reset state')
      state.MODE = 'ADD';
      state.enableSubmit = true;
      state.isReadOnly = false,
        state.isLoading = true,
        state.isShowConfirmDelete = false;
      state.isShowConfirmClose = false;
      state.pageIndex = 1;
      state.pageSize = 20;
    },
    setIsShowMenuDetail: (state, payload) => state.isShowMenuDetail = payload,
    setIsCustomer: (state, payload) => state.isCustomer = payload,
    setIsOrganization: (state, payload) => state.isOrganization = payload,
    setVendorGroup: (state, payload) => state.vendorGroup = payload,
    setX: (state, payload) => state.X = payload,
    setEmployee: (state, payload) => state.employee = payload,
    setVendors: (state, payload) => state.vendors = payload,
    setRPL: (state, payload) => state.RPL = payload,
    setAccounts: (state, payload) => state.accounts = payload,
    setIsLoading: (state, payload) => state.isLoading = payload,
    setMODE: (state, payload) => state.MODE = payload,
    setEnableSubmit: (state, payload) => state.enableSubmit = payload,
    setIsShowVendorDialog: (state, payload) => state.isShowVendorDialog = payload,
    setIsShowAccountDialog: (state, payload) => state.isShowAccountDialog = payload,
    setIsShowRPDialog: (state, payload) => state.isShowRPDialog = payload,
    setIsReadOnly: (state, payload) => state.isReadOnly = payload,
    setPageIndex: (state, payload) => state.pageIndex = payload,
    setPageSize: (state, payload) => state.pageSize = payload,
    setNewVendorCode: (state, payload) => state.newVendorCode = payload,
    setNewVoucherNumber: (state, payload) => state.newVoucherNumber = payload,
    setIsShowConfirmDelete: (state, payload) => state.isShowConfirmDelete = payload,
    setIsShowConfirmClose: (state, payload) => state.isShowConfirmClose = payload,
    setTotal: (state, payload) => state.total = payload,
    setTotalRPL: (state, payload) => state.totalRPL = payload,
    setTotalAccount: (state, payload) => state.totalAccount = payload,
    setDeepLevel: (state, payload) => state.deepLevel = payload,
  },
  actions: {
    setVendors: context => {
      const pageIndex = context.getters.getPageIndex;
      const pageSize = context.getters.getPageSize;
      const API_URL = context.getters.getApiUrl + `/vendors/paging?pageIndex=${pageIndex}&pageSize=${pageSize}`;

      try {
        return axios.get(API_URL)
          .then(async response => {
            context.commit('setVendors', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
            context.commit('setTotal', response.data.Total); // set page size
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },
    setVendorFilter: (context, keywords) => {
      try {
        const pageIndex = context.getters.getPageIndex;
        const pageSize = context.getters.getPageSize;
        const API_URL = context.getters.getApiUrl + `/vendors/filter?keywords=${keywords}&pageIndex=${pageIndex}&pageSize=${pageSize}`;
        axios.get(API_URL)
          .then(async response => {
            context.commit('setTotal', response.data.Total); // set page size
            context.commit('setVendors', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },

    setNewVendorCode: context => {
      try {
        const API_URL = context.getters.getApiUrl + '/vendors/new-code';
        axios.get(API_URL)
          .then(response => {
            context.commit('setNewVendorCode', response.data.Data);
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },

    setAccounts: context => {
      const API_URL = context.getters.getApiUrl + `/accounts`;

      try {
        return axios.get(API_URL)
          .then(async response => {
            context.commit('setAccounts', response.data.Data);
            context.commit('setTotalAccount', response.data.Data.length);
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },

    setRPL: context => {
      const pageIndex = context.getters.getPageIndex;
      const pageSize = context.getters.getPageSize;
      const API_URL = context.getters.getApiUrl + `/receiptpayments/paging?pageIndex=${pageIndex}&pageSize=${pageSize}`;
      try {
        return axios.get(API_URL)
          .then(async response => {
            context.commit('setRPL', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
            context.commit('setTotalRPL', response.data.Total); // set page size
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },

    setRPFilter: (context, keywords) => {
      try {
        const pageIndex = context.getters.getPageIndex;
        const pageSize = context.getters.getPageSize;
        const API_URL = context.getters.getApiUrl + `/receiptpayments/filter?keywords=${keywords}&pageIndex=${pageIndex}&pageSize=${pageSize}`;
        axios.get(API_URL)
          .then(async response => {
            context.commit('setTotalRPL', response.data.Total); // set page size
            context.commit('setRPL', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
          })
          .catch(error => {
            console.log('%c[ERROR]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR]:', 'color: red', error);
      }
    },

    setNewVoucherNumber: context => {
      try {
        const API_URL = context.getters.getApiUrl + '/receiptpayments/new-code';
        return axios.get(API_URL)
          .then(response => {
            context.commit('setNewVoucherNumber', response.data.Data);
          })
          .catch(error => {
            console.log('%c[ERROR][From Vuex]:', 'color: red', error);
          })
      } catch (error) {
        console.log('%c[ERROR][From Vuex]:', 'color: red', error);
      }
    },
  }
});