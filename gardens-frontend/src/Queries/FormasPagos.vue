<template>
    <div class="container">
        <h2 class='item_title'>Formas de Pagos</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Forma Pago</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(val, key) in formasPagosList" :key="key">
                    <td>{{ val.formaPago }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            formasPagosList: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listFormasPagos();
    },
    methods: {
        listFormasPagos() {
            axios.get(this.API_IIS + '/api/Pago/FormasPagos', { withCredentials: true })
                .then(response => {
                    this.formasPagosList = response.data;
                })
                .catch(error => {
                    console.error('Error al mostrar la lista de FormasPagos', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de FormasPagos. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>