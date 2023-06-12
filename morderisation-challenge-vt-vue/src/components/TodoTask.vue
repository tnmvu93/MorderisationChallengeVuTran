<template>
  <table>
    <thead>
      <th>1</th>
      <th>2</th>
    </thead>
    <tbody>
      <tr v-for="task in tasks" :key="task.id">
        <td>
          <input type="checkbox" v-model="task.completed" @change="complete(task.id)">
        </td>
        <td>{{ task.details }}</td>
      </tr>
      <tr>
        <button type="button" @click="openTaskPopup">+ Create a new task</button>
      </tr>
    </tbody>
  </table>
</template>

<script>
import api from '@/apiservice';

export default {
  name: 'TodoTask',
  data() {
    return {
      tasks: []
    }
  },
  async created() {
    this.getAll();
  },
  methods: {
    async getAll() {
      this.tasks = await api.getAll();
    },
    async complete(id) {
      await api.complete(id);
    },
    async openTaskPopup() {

    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
