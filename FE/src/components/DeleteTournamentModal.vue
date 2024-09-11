<template>
    <div class="q-pa-md q-gutter-sm">
        <q-dialog v-model="closed">
            <q-card style="width: 700px; max-width: 80vw;">
                <q-card-section>
                    <div class="text-h6">Delete</div>
                </q-card-section>

                <q-card-section class="q-pt-none">
                    Are you sure you want to delete the tournament ?
                </q-card-section>

                <q-card-actions align="right" class="bg-white text-teal">
                    <q-btn @click="handleClose" flat label="Cancel" v-close-popup />
                    <q-btn @click="handleDelete" flat label="Delete" v-close-popup />
                </q-card-actions>
            </q-card>
        </q-dialog>
    </div>
</template>

<script setup>
import { ref } from 'vue';
import { useTournamentStore } from 'src/stores/tournamentsStore';

const tournamentStore = useTournamentStore()

const closed = ref(true)
const emits = defineEmits(['update:modelValue'])
const props = defineProps({
    id: {
        type: String,
        required: true
    }
})
const handleClose = () => {
    emits('update:modelValue', false)
}

const handleDelete = () => {
    const id = props.id;
    tournamentStore.deleteTournament(id)
    emits('update:modelValue', false)
    tournamentStore.init()
}
</script>