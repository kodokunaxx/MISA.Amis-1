import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
        isShowMenuDetail: true,
        x: -10000,
        y: -10000,
    },
    getters: {
        getIsShowMenuDetail: state => state.isShowMenuDetail,
        getX: state => state.x,
        getY: state => state.y,
    },
    mutations: {
        setIsShowMenuDetail: (state, payload) => state.isShowMenuDetail = payload,
        setX: (state, payload) => state.x = payload,
        setY: (state, payload) => state.y = payload,
    },
    actions: {

    }
});