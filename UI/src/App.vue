<template>
  <div id="app">
    <AppLayout> </AppLayout>
    <!-- <Input :w="500" :color="'red'" :isRequired=true :placeHolder="'test'" :className="['test1', 'test2']"></Input> -->
  </div>
</template>

<script>
import AppLayout from "./components/layout/AppLayout";
// import Input from './components/base/Input';
import "vue-search-select/dist/VueSearchSelect.css";

export default {
  name: "App",
  components: {
    AppLayout,
    // Input,
  },
};
</script>

<style lang="scss">
@import "./styles/common.css";
@import "./styles/main.css";

#app {
  color: #111;
  width: 100vw;
  height: 100vh;
  overflow: hidden;
  li {
    list-style: none;
  }
}
@keyframes clockwise {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
}

@keyframes anticlockwise {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(-180deg);
  }
}

@keyframes clockwise2 {
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(180deg);
  }
}
</style>
