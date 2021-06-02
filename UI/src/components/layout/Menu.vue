<template>
  <div class="body-left" ref="misaMenu">
    <div class="sidebar">
      <div class="toggle" v-if="this.$store.getters.getIsShowMenuDetail"></div>
      <div
        class="extend"
        @click="extendMenu()"
        v-if="!this.$store.getters.getIsShowMenuDetail"
      ></div>
      <router-link to="/vendor">
        <div
          class="logo"
          v-show="this.$store.getters.getIsShowMenuDetail"
        ></div>
      </router-link>
    </div>

    <div class="menu">
      <router-link to="/" class="menu-item">
        <span class="icon"></span>
        <span class="text" v-show="this.$store.getters.getIsShowMenuDetail">
          Tiền mặt
        </span>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  updated() {
    if (this.$store.getters.getIsShowMenuDetail) {
      this.$refs.misaMenu.style.width = "178px";
    } else {
      this.$refs.misaMenu.style.width = "52px";
    }
  },
  methods: {
    extendMenu() {
      this.$store.commit("setIsShowMenuDetail", true);
    },
  },
};
</script>

<style lang="scss">
a {
  text-decoration: none;
  color: #fff;
}
.body-left {
  background-color: #38393d;
  width: 178px;
  height: 100vh;
  border-right: 1px solid #bbbbbb;
  display: flex;
  flex-direction: column;
}

.body-left .sidebar {
  height: 50px;
  display: flex;
  align-items: center;
  padding-left: 16px;
  /* justify-content: center; */
}

.body-left .sidebar .toggle,
.extend {
  width: 24px;
  height: 24px;
  margin-right: 10px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
  background-position: -424px -86px;

  cursor: pointer;
}
.extend {
  background-position: -312px -32px;
}

.body-left .sidebar .logo {
  width: 96px;
  height: 32px;
  background-image: url("../../assets/img/Logo_Module_TiengViet_White.66947422.svg");
  background-size: 97px;
  background-repeat: no-repeat;
  background-position: center;
  cursor: pointer;
}

.body-left .menu {
  display: flex;
  padding-top: 10px;
  flex-direction: column;
}

.body-left .menu .menu-item {
  display: flex;
  align-items: center;
  cursor: pointer;
  height: 42px;
  border-left: 6px solid transparent;
  .icon {
    display: inline-block;
    width: 24px;
    height: 24px;
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat;
    background-position: -73px -1585px;
    margin-right: 8px;
    margin-left: 8px;
  }
}

.body-left .menu .menu-item:hover {
  background-color: #616164;
}
</style>
