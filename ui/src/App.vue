<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/about">About</router-link>
    </div>
    <router-view/>
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

  .table-center {
    margin-left:auto;
    margin-right:auto;
    column-gap:60px;
    border: 1px solid black;
    border-collapse: collapse;
  }
  td {
    border: 1px solid black;
    padding: 5px;
  }
  th {
    border: 1px solid black;
    padding: 10px;
  }

#loader {
  border: 12px solid #f3f3f3;
  border-radius: 50%;
  border-top: 12px solid #444444;
  width: 70px;
  height: 70px;
  animation: spin 1s linear infinite;
}

.newButton {
  background-color: #ff9933;
  border: none;
  color: white;
  padding: 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  border-radius: 12px;
}

.newButton:hover {
  background-color: #ff6600;
  cursor: pointer;
}

.baseButton {
  background-color: lightgray;
  border: none;
  color: black;
  padding: 10px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 12px;
  margin: 4px 2px;
  border-radius: 12px;
}

.baseButton:hover {
  background-color: dimgrey;
  cursor: pointer;
}

@keyframes spin {
  100% {
    transform: rotate(360deg);
  }
}

</style>
