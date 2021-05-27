<template>
  <div id="app">
    <Header />
    <Menu />
    <Content />
  </div>
</template>

<script>
import Header from "./components/layout/Header";
import Menu from "./components/layout/Menu";
import Content from "./components/layout/Content";

export default {
  name: "App",
  components: {
    Header,
    Menu,
    Content,
  },
};
</script>

<style lang="scss">
@import "./css/font.css";
@import "./css/text-align.css";

* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}
#app {
  width: 100vw;
  height: 100vh;
  font-size: 13px;
  font-family: "GoogleSans-Regular";
  overflow: hidden;
  .d-flex {
    display: flex;
    justify-content: center;
    align-items: center;
  }
}
a {
  text-decoration: none;
}
li {
  list-style: none;
}
/* width */
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f1;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #888;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555;
}
</style>
