<template>
    <div class="login-container">
        <form class="login-form" @submit.prevent="handleLogin">
            <label class="login-label">Username:</label>
            <input v-model="username" placeholder="Enter your username" class="login-input" type="text" required />
            <label class="login-label">Password:</label>
            <input v-model="password" placeholder="Enter your password" class="login-input" type="password" required />
            <button class="login-button" type="submit">Login</button>
            <button class="redirect-button" @click="redirectToSignUp">Don't have an account? Sign Up</button>
        </form>
        <p v-if="error" class="error-message">{{ error }}</p>
    </div>
</template>

<script>
import Swal from 'sweetalert2';
import router from '../Router/index.js';

export default {
    data() {
        return {
            username: '',
            password: '',
            error: null,
            API_URL: process.env.VUE_APP_API_URL
        };
    },
    methods: {
        async handleLogin() {
            try {
                const response = await fetch(this.API_URL + '/api/Auth/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ username: this.username, password: this.password })
                });

                const data = await response.text();
                if (response.ok && data !== "User not found." && data !== "Wrong password.") {
                    // Successful login, received token
                    document.cookie = `access_token=${data}; path=/`;
                    Swal.fire({
                        icon: 'success',
                        title: 'Login Successful!',
                        text: 'You have successfully logged in.',
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: true
                    }).then(() => {
                        this.$emit('authentication-success');
                    });
                } else {
                    // Login failed, display error message
                    this.error = data || 'Login error';
                    Swal.fire({
                        icon: 'error',
                        title: 'Login Error',
                        text: this.error,
                        timer: 3000,
                        timerProgressBar: true,
                        showConfirmButton: false
                    });
                }
            } catch (error) {
                console.error('Network Error:', error);
                this.error = 'Network Error: Could not connect to the server';
                Swal.fire({
                    icon: 'error',
                    title: 'Network Error',
                    text: this.error,
                    timer: 3000,
                    timerProgressBar: true,
                    showConfirmButton: false
                });
            }
        }
        ,
        redirectToSignUp() {
            router.push({ name: 'SignUp' });
        }
    }
};
</script>

<style scoped>
.login-container {
    height: 100vh;
    overflow-y: hidden;
    display: flex;
    justify-content: center;
    align-items: center;
}

.login-form {
    width: 300px;
    padding: 20px;
    background-color: #f2f2f2;
    border-radius: 8px;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
}

.login-label {
    margin-bottom: 5px;
    font-weight: bold;
}

.login-input {
    width: 100%;
    padding: 8px;
    margin-bottom: 15px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

.login-button {
    width: 100%;
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.login-button:hover {
    background-color: #0056b3;
}

.error-message {
    color: red;
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
