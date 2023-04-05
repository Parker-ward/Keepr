<template>
  <!-- TODO after moving modal here, make sure I still import this component -->

  <div class="modal" tabindex="-1" id="keepDetails">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">{{ keep.name }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
              <div class="col-md-6 ">
                <img class="img-fluid pb-2" :src="keep.img" alt="">
              </div>
              <!-- <div class="container-fluid">
                <div class="row"> -->
              <div class="col-md-6">
                {{ keep.description }}
                <!-- </div>
                    </div> -->
              </div>
            </div>
            <div class="d-flex justify-content-between">
              <div class="dropdown">
                <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  Dropdown button
                </button>
                <ul class="dropdown-menu">
                  <li><a class="dropdown-item" href="#">Action</a></li>
                  <li><a class="dropdown-item" href="#">Another action</a></li>
                  <li><a class="dropdown-item" href="#">Something else here</a></li>
                </ul>
              </div>
              <router-link :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                <img data-bs-dismiss="modal" data-bs-target="#keepDetails" class="rounded-circle creator-img"
                  :src="keep.creator.picture" alt="">

              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<!-- NOTE bootstrap works in modals!! to get side:side use a col-6 -->

<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';



export default {

  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
    };
  },

}
</script>


<style lang="scss" scoped>
.creator-img {
  height: 50px;
}
</style>