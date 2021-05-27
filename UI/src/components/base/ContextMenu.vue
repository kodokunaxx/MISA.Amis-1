<template>
  <div
    class="MISAContext-Menu"
    ref="contextMenu"
    :valueX="this.$store.getters.getX"
    :valueY="this.$store.getters.getY"
  ></div>
</template>

<script>
export default {
  data() {
    return {
      x: 100,
      y: 100,
    };
  },
  methods: {
    setPosition(x, y) {
      this.$refs.contextMenu.style.left = x + "px";
      this.$refs.contextMenu.style.top = y + "px";
    },
  },
  updated() {
    let x = this.$store.getters.getX;
    let y = this.$store.getters.getY;
    this.setPosition(x, y);
  },
};
</script>

<style lang="scss">
.MISAContext-Menu {
  position: fixed;
  top: -10000px;
  left: -10000px;
  width: 100px;
  height: 100px;
  background-color: red;
  z-index: 789;
}
</style>
