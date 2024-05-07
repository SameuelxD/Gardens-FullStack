<template>
    <div class="container">
        <h2 class="item_title">Informacion Oficinas 1</h2>
        <table class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Código Oficina</th>
                    <th scope="col">Ciudad</th>
                    <th scope="col">Pais</th>
                    <th scope="col">Region</th>
                    <th scope="col">Codigo Postal</th>
                    <th scope="col">Telefono</th>
                    <th scope="col">Direccion</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(oficina, index) in oficinas1List" :key="index">
                    <td>{{ oficina.codigoOficina }}</td>
                    <td>{{ oficina.ciudad }}</td>
                    <td>{{ oficina.pais }}</td>
                    <td>{{ oficina.region }}</td>
                    <td>{{ oficina.codigoPostal }}</td>
                    <td>{{ oficina.telefono }}</td>
                    <td>{{ oficina.lineaDireccion1 }} {{ oficina.lineaDireccion2 }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    data() {
        return {
            oficinas1List: [],
            API_URL: process.env.VUE_APP_API_URL,
            API_IIS: process.env.VUE_APP_API_IIS
        };
    },
    mounted() {
        this.listOficinas1();
    },
    methods: {
        listOficinas1() {
            axios.get(this.API_IIS + '/api/Oficina/Oficinas1', { withCredentials: true })
                .then(response => {
                    this.oficinas1List = response.data;
                })
                .catch(error => {
                    console.log("Error al mostrar la lista de Oficinas1 ", error);
                    Swal.fire({
                        icon: 'error',
                        title: 'Error',
                        text: 'Ocurrió un error al mostrar la lista de Oficinas1. Por favor, inténtalo de nuevo más tarde.',
                        footer: `Detalles del error: ${error.message}`
                    });
                });
        }
    }
};
</script>

<style scoped></style>