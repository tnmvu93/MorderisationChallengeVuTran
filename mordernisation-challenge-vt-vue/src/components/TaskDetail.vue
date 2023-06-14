<template>
  <div>
    <form @submit.prevent="save" novalidate="true">
      <div class="dialogue" role="dialog">
        <div style="width: 750px">
          <div class="header">
            <a href="#" class="close" @click="close"></a>
            <h2>{{ title }}</h2>
          </div>
          <div class="body">
            <fieldset class="required">
              <label>Details</label>
              <textarea
                rows="2"
                cols="20"
                class="text"
                style="height: 100px"
                v-model="task.details"
                required
              >
              </textarea>
            </fieldset>
          </div>
          <div class="footer">
            <p class="commands">
              <span class="grow"></span>
              <button class="button hollow" @click="close">Cancel</button>
              <button class="button" type="submit">Save</button>
            </p>
          </div>
        </div>
      </div>
    </form>
    <div class="overlay visible"></div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Task from "@/models/Task";
import ApiService from "@/ApiService";

@Component
export default class TaskDetail extends Vue {
  private task: Task = {
    id: null,
    details: "",
    completed: false,
  };

  private title = "";

  getTask(id: number) {
    ApiService.get(id)
      .then((response) => {
        if (response) {
          this.task.id = response.id;
          this.task.details = response.details;
          this.task.completed = response.completed;
        }
      })
      .catch((e) => {
        console.log(e);
      });
  }

  async save() {
    if (this.task.details) {
      if (this.task.id === null) {
        await this.createTask();
      } else {
        await this.updateTask();
      }

      this.$router.push({ name: "list" });
    }
  }

  // My technical debt here, one request to server when cancel due to my knownledge of closing the modal.
  close() {
    this.$router.push({ name: "list" });
  }

  private async createTask() {
    let data = {
      details: this.task.details,
    };

    return ApiService.create(data)
      .then((response) => {
        this.task.id = response.id;
      })
      .catch((e) => {
        console.log(e);
      });
  }

  private updateTask() {
    let data = {
      id: this.task.id,
      details: this.task.details,
    };

    return ApiService.update(data)
      .then((response) => {
        this.task.id = response.id;
      })
      .catch((e) => {
        console.log(e);
      });
  }

  mounted() {
    if (this.$route.params.id) {
      this.title = "Edit task";
      let id = parseInt(this.$route.params.id);
      this.getTask(id);
    } else {
      this.title = "Create task";
    }
  }
}
</script>
