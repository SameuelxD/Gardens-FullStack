<template>
    <div class="signup-container">
        <form class="signup-form" @submit.prevent="handleSignUp">
            <label class="signup-label">Username:</label>
            <input v-model="username" placeholder="Enter your username" class="signup-input" type="text" required />
            <label class="signup-label">Email:</label>
            <input v-model="email" placeholder="Enter your email" class="signup-input" type="email" required />
            <label class="signup-label">Password:</label>
            <input v-model="password" placeholder="Enter your password" class="signup-input" type="password" required />
            <button class="signup-button" type="submit">Sign Up</button>
        </form>
        <p v-if="registrationSuccessful" class="success-message">Registration successful!</p>
        <button class="redirect-button" @click="redirectToSignIn">Already have an account? Sign In</button>
    </div>
</template>

<script>
import Swal from 'sweetalert2';
import router from '../Router/index.js'

export default {
    data() {
        return {
            username: '',
            email: '',
            password: '',
            registrationSuccessful: false,
            API_URL: process.env.VUE_APP_API_URL
        };
    },
    methods: {
        async handleSignUp() {
            try {
                const response = await fetch(this.API_URL + '/api/Auth/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        Username: this.username,
                        Email: this.email,
                        Password: this.password,
                    })
                });

                console.log(response);

                const data = await response.text(); // Obtener el texto de la respuesta

                if (response.ok && data.includes('success')) {
                    this.registrationSuccessful = true;
                    this.username = '';
                    this.email = '';
                    this.password = '';


                    // Mostrar respuesta usando Swal2
                    Swal.fire({
                        icon: 'success',
                        title: 'Registration Successful!',
                        text: 'You have been successfully registered.\n' + data, // Agregar la respuesta como texto
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: true
                    }).then(() => {
                        this.$emit('registration-success');
                    });
                } else {
                    // Mostrar respuesta de error usando Swal2
                    Swal.fire({
                        icon: 'error',
                        title: 'Registration Error',
                        text: 'Registration error:\n' + data, // Agregar la respuesta como texto
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: true
                    });
                }
            } catch (error) {
                console.error('Network Error:', error);
                // Mostrar mensaje de error usando Swal2
                Swal.fire({
                    icon: 'error',
                    title: 'Network Error',
                    text: 'Could not connect to the server.',
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: true
                });
            }
        },

        redirectToSignIn() {
            // Redirige al usuario al componente SignIn.vue
            router.push({ name: 'SignIn' });
        }
    }
};
</script>

<style scoped>
.signup-container {
    width: 100%;
    max-width: 400px;
    margin: 0 auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;
    background-color: #f9f9f9;
}

.signup-form {
    display: flex;
    flex-direction: column;
}

.signup-label {
    margin-bottom: 8px;
    font-weight: bold;
}

.signup-input {
    margin-bottom: 16px;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

.signup-button {
    padding: 10px 20px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.signup-button:hover {
    background-color: #0056b3;
}

.success-message {
    margin-top: 16px;
    color: green;
}

.redirect-button {
    background-color: transparent;
    border: none;
    cursor: pointer;
    color: #007bff;
    text-decoration: underline;
    margin-top: 10px;
}
</style>
