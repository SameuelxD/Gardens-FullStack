<template>
    <div class="container">
        <h2 class="item_title">Pagos Paypal 2008</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Cliente</th>
                    <th scope="col">Forma Pago</th>
                    <th scope="col"># ID Transacción</th>
                    <th scope="col">Fecha Pago</th>
                    <th scope="col">Total</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(payment, index) in pagosPaypal2008List" :key="index">
                    <td>{{ payment.codigoCliente }}</td>
                    <td>{{ payment.formaPago }}</td>
                    <td>{{ payment.idTransaccion }}</td>
                    <td>{{ payment.fechaPago }}</td>
                    <td>{{ payment.total }}</td>
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
            pagosPaypal2008List: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    created() {
        this.listPagosPaypal2008();
    },
    methods: {
        listPagosPaypal2008() {
            axios.defaults.withCredentials = true;
            axios.get(this.API_IIS + '/api/Pago/Pagos2008Paypal', { withCredentials: true })
                .then(response => {
                    this.pagosPaypal2008List = response.data;
                })
                .catch(error => {
                    console.error('Error al mostrar la lista de PagosPaypal2008', error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de PagosPaypal2008. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>