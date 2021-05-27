<template>
  <div>
    <Menu></Menu>
    <div class="body-right">
      <Header> </Header>
      <router-view />
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
}
.body-right .MISAVendor {
  padding: 0px 30px 0px 0px;
  height: calc(100vh - 50px);
  margin-left: 20px;
}
#app {
  color: #111;
}
</style>
