<template>
  <ul class="MISANode">
    <!-- ------------------------------- -->
    <div
      class="Parent"
      v-if="Array.isArray(node) && node.length > 1"
      @click="toggle()"
    ></div>
    <!-- ------------------------------- -->
    <div v-if="isShowDetail">
      <!-- -------------------- -->
      <li v-if="!Array.isArray(node)" class="Row">
        <div class="Column" v-for="(column, index) in node" :key="index">
          {{ column }}
        </div>
      </li>
      <!-- -------------------- -->

      <!-- -------------------- -->
      <li v-else v-for="(ele, index) in node" :key="index">
        <node :node="ele"></node>
      </li>
      <!-- -------------------- -->
      
    </div>
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
      this.isShowDetail = !this.isShowDetail;
    },
  },
};
</script>

<style></style>
