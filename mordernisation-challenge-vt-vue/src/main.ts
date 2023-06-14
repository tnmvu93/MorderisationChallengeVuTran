import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import vClickOutsdie from "v-click-outside";

Vue.use(vClickOutsdie);

Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
