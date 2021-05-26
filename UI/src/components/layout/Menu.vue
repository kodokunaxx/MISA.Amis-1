<template>
  <div class="MISAMenu">
    <div class="MISAMenu-Logo">
      <div class="option"></div>
      <div class="logo">
        <img
          src="../../assets/img/Logo_Module_TiengViet_White.66947422.svg"
          alt=""
        />
      </div>
    </div>
    <ul class="MISAMenu-Category">
      <li class="category" title="Nhà cung cấp">
        <span class="icon"></span>
        <router-link to="/vendor">
          Nhà cung cấp
        </router-link>
      </li>
      <li class="category" title="Hệ thống tài khoản">
        <span class="icon"></span>
        <router-link to="/account">
          Hệ thống tài khoản
        </router-link>
      </li>
      <li class="category" title="Phiếu chi">
        <span class="icon"></span>
        <router-link to="/payment">
          Phiếu chi
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss">
.MISAMenu {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  width: 178px;
  height: 100vh;
  background-color: #393a3d;
  .MISAMenu-Logo {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 48px;
    .option {
      width: 24px;
      height: 24px;
      margin-right: 10px;
      background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg")
        no-repeat -424px -86px;
      cursor: pointer;
    }
    .logo {
      margin-top: 4px;
      cursor: pointer;
      img {
        display: inline-block;
        width: 96px;
        height: 32px;
      }
    }
  }
  .MISAMenu-Category {
    width: 100%;
    padding: 0;
    li {
      display: flex;
      align-items: center;
      list-style: none;
      height: 42px;
      line-height: 42px;
      padding-left: 8px;
      cursor: pointer;
      white-space: nowrap;
      overflow: hidden;
      a {
        color: #fff;
        display: inline-block;
        width: 100%;
        height: 100%;
        text-decoration: none;
      }
      .icon {
        display: inline-block;
        width: 24px;
        height: 24px;
        margin: 0 10px;
        background: url("https://actappg1.misacdn.net/img/Sprites.f6ab0897.svg") no-repeat;
        background-position: -33px -1628px;
      }
    }
  }
}
</style>
