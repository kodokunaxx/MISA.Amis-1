<template>
  <div>
    <Menu></Menu>
    <div class="body-right">
      <Header> </Header>
      <div class="Fixed Left"></div>
      <router-view />
      <div class="Fixed Right"></div>
    </div>
  </div>
</template>

<script>
import Menu from "./Menu.vue";
import Header from "./Header.vue";

export default {
  name: "AppLayout",
  components: {
    Menu,
    Header,
  },
};
</script>

<style scoped lang="scss">
div {
  display: flex;
}

.body-right {
  flex: 1;
  top: 0;
  right: 0;
  bottom: 0;
  background-color: #f4f5f6;
  flex-direction: column;
  overflow: hidden;
  position: relative;
  .Fixed {
    position: fixed;
    top: 50px;
    bottom: 0;
    background-color: #f4f5f8;
    z-index: 999;
    &.Left {
      left: 178px;
      width: 20px;
    }
    &.Right {
      right: 10px;
      width: 37px;
    }
  }
}
</style>
