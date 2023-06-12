<template>
  <div id="app">
    <TodoTask />
  </div>
</template>

<script>
import TodoTask from './components/TodoTask.vue'

export default {
  name: 'App',
  components: {
    TodoTask
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
