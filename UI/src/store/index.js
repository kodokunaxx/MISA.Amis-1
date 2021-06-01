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
    newVendorCode: null,
    enableSubmit: true,
    isReadOnly: false,
    isLoading: true,
    isShowMenuDetail: true,
    isShowVendorDialog: false,
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
    pageSize: 0,
  },
  getters: {
    getApiUrl: state => state.API_URL,
    getMODE: state => state.MODE,
    getIsLoading: state => state.isLoading,
    getVendors: state => state.vendors,
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
    getIsReadOnly: state => state.isReadOnly,
    getPageSize: state => state.pageSize,
    getNewVendorCode: state => state.newVendorCode,
    getIsShowConfirmDelete: state => state.isShowConfirmDelete,
    getIsShowConfirmClose: state => state.isShowConfirmClose,

  },
  mutations: {
    setIsShowMenuDetail: (state, payload) => state.isShowMenuDetail = payload,
    setIsCustomer: (state, payload) => state.isCustomer = payload,
    setIsOrganization: (state, payload) => state.isOrganization = payload,
    setVendorGroup: (state, payload) => state.vendorGroup = payload,
    setX: (state, payload) => state.X = payload,
    setEmployee: (state, payload) => state.employee = payload,
    setVendors: (state, payload) => state.vendors = payload,
    setIsLoading: (state, payload) => state.isLoading = payload,
    setMODE: (state, payload) => state.MODE = payload,
    setEnableSubmit: (state, payload) => state.enableSubmit = payload,
    setIsShowVendorDialog: (state, payload) => state.isShowVendorDialog = payload,
    setIsReadOnly: (state, payload) => state.isReadOnly = payload,
    setPageSize: (state, payload) => state.pageSize = payload,
    setNewVendorCode: (state, payload) => state.newVendorCode = payload,
    setIsShowConfirmDelete: (state, payload) => state.isShowConfirmDelete = payload,
    setIsShowConfirmClose: (state, payload) => state.isShowConfirmClose = payload,
  },
  actions: {
    setVendors: context => {
      const API_URL = context.getters.getApiUrl + '/vendors';
      try {
        axios.get(API_URL)
          .then(async response => {
            context.commit('setVendors', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
            context.commit('setPageSize', response.data.Data.length); // set page size
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
        const API_URL = context.getters.getApiUrl + `/vendors/filter?keywords=${keywords}`;
        axios.get(API_URL)
          .then(response => {
            context.commit('setVendors', response.data.Data);
            context.commit('setIsLoading', false); // Tắt hiệu ứng loading
            context.commit('setPageSize', response.data.Data.length); // set page size
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
    }
  }
});