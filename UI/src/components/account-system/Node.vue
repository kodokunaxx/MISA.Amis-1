<template>
  <ul class="MISANode">
    <!-- ------------------------------- -->
    <div
      class="Parent"
      v-if="Array.isArray(node) && node.length > 1"
      @click="toggle()"
    ></div>
    <!-- ------------------------------- -->

    <!-- -------------------- -->
    <li v-if="!Array.isArray(node)" class="Row XYZ">
      <div class="Column" v-for="(column, index) in node" :key="index">
        {{ column }}
      </div>
    </li>
    <!-- -------------------- -->

    <!-- -------------------- -->
    <li v-else v-for="(ele, index) in node" :key="index" ref="test">
      <node :node="ele"></node>
    </li>
    <!-- -------------------- -->

    <!-- ------------------------------- -->
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
      console.log(this.$refs.test);
      //   this.$refs.test.style.display = "none";
    },
  },
};
</script>

<style></style>
