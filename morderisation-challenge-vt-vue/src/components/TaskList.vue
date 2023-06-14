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
                @click="focus(task.id, $event)"
                :key="task.id"
              >
                <span
                  v-if="isFocus(task.id)"
                  :style="popupMenuStyle"
                  v-click-outside="unfocus"
                >
                  <RouterLink :to="`/update/${task.id}`">Edit</RouterLink>
                  <a href="#" @click="deleteTask(task.id, $event)">Delete</a>
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
  private focusId = -1;
  private popupMenuPosition = {
    left: 0,
    top: 0,
  };

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

  async deleteTask(id: number, $event: any) {
    if (confirm("Are you sure that you want to delete this task?")) {
      await ApiService.delete(id);
      this.getAll();
    } else {
      this.unfocus();
      $event.stopPropagation();
    }
  }

  focus(id: number, $event: any) {
    if (typeof id === "number") {
      this.focusId = id;
      this.calculatePopupPosition($event);
    }
  }

  unfocus() {
    this.focusId = -1;
  }

  isFocus(id: number) {
    return this.focusId === id;
  }

  calculatePopupPosition($event: any) {
    if ($event && $event.target) {
      let focusPosition = $event.target.getBoundingClientRect();
      if (focusPosition) {
        this.popupMenuPosition.left = focusPosition.left;
        this.popupMenuPosition.top =
          focusPosition.top + focusPosition.height + 1;
      }
    }
  }

  get popupMenuStyle() {
    return `left:${this.popupMenuPosition.left}px;top:${this.popupMenuPosition.top}px`;
  }
}
</script>
