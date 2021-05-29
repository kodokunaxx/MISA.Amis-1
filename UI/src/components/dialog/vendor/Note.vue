<template>
  <div class="Note">
    <Textarea  :w="'100%'" :height="'200px'" :field="'NoteContent'"/>
  </div>
</template>

<script>
import Textarea from '../../base/Textarea'

export default {
  components: {
    Textarea,
  },
};
</script>

<style lang="scss"></style>
