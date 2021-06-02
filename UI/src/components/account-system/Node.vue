<template>
  <ul class="MISANode">
    <!------------------------------------------------------------->
    <li class="Row">
      <div class="Column" v-for="(column, index) in node.parent" :key="index">
        {{ column }}
      </div>
    </li>
    <!------------------------------------------------------------->
    

    <!------------------------------------------------------------->
    <li v-if="isShowDetail && node.children && node.children.length">
      <node v-for="(child, i) in node.children" :key="i" :node="child"></node>
    </li>
    <!------------------------------------------------------------->
    

    <!------------------------------------------------------------->
    <div
      class="icon"
      v-if="node.children && node.children.length"
      @click="toggle()"
    ></div>
    <!------------------------------------------------------------->
  </ul>
</template>

<script>
export default {
  name: "node",
  props: ["node"],
  data() {
    return {
      isShowDetail: true,
    };
  },
  methods: {
    toggle() {
      this.isShowDetail = !this.isShowDetail;
    },
  },
};
</script>

<style></style>
