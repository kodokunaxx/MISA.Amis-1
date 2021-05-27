<template>
  <div
    class="MISAContent"
    ref="mainContent"
    :value="this.$store.getters.getIsShowMenuDetail"
  >
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  updated() {
    if (this.$store.getters.getIsShowMenuDetail) {
      this.$refs.mainContent.style.left = "178px";
    } else {
      this.$refs.mainContent.style.left = "52px";
    }
  },
};
</script>

<style lang="scss">
.MISAContent {
  position: absolute;
  top: 48px;
  left: 178px;
  right: 0;
  bottom: 0;
}
</style>
