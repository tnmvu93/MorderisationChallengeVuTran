<template>
  <div>
    <h1>Tasks</h1>
    <div class="table">
      <table class="table">
        <thead>
          <tr>
            <th style="width: 1px">Completed</th>
            <th>Details</th>
            <th style="width: 1px"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="task in tasks" :key="task.id">
            <td style="text-align: center; width: 1px">
              <span class="checkbox">
                <input
                  type="checkbox"
                  v-model="task.completed"
                  @change="complete(task.id, $event)"
                />
              </span>
            </td>
            <td>
              {{ task.details }}
            </td>
            <td style="width: 1px">
              <span
                class="popup_menu"
                :class="{ focus: isFocus(task.id) }"
                @click="focus(task.id)"
                :key="task.id"
              >
                <span v-if="isFocus(task.id)">
                  <RouterLink :to="`/update/${task.id}`">Edit</RouterLink>
                  <a href="#" @click="deleteTask(task.id)">Delete</a>
                </span>
              </span>
            </td>
          </tr>
          <tr class="info">
            <td colspan="99">
              <RouterLink :to="`/create`">+ Create a new task</RouterLink>
            </td>
          </tr>
        </tbody>
      </table>

      <router-view></router-view>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Task from "@/models/Task";
import ApiService from "@/ApiService";

@Component
export default class TaskList extends Vue {
  private tasks: Task[] = [];
  private isShowCommands = false;
  private focusId = -1;

  mounted() {
    this.getAll();
  }

  getAll() {
    ApiService.getAll()
      .then((response) => {
        this.tasks = response;
      })
      .catch((e) => {
        console.log(e);
      });
  }

  complete(id: number, $event: any) {
    let data = {
      id: id,
      completed: $event.target.checked,
    };
    ApiService.complete(data);
  }

  async deleteTask(id: number) {
    await ApiService.delete(id);

    this.$router.go(0);
  }

  focus(id: number) {
    this.focusId = id;
  }

  isFocus(id: number) {
    return this.focusId === id;
  }
}
</script>
