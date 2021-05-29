<template>
  <div class="MISABase-Loading">
    <img src="../../assets/img/loading.svg" alt="" />
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.MISABase-Loading {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  //   background-color: rgba($color: #ffffff, $alpha: 0.1);
  background-color: rgba($color: #000000, $alpha: 0.6);
  z-index: 1000;
  img {
    animation: clock 1s infinite;
  }
}

@keyframes clock {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
