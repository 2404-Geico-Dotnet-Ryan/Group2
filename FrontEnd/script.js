const BASE_URL = " http://localhost:5238";
let current_user = {};
/*
  <div id="user-container" class="float-container">
    <input type="checkbox" id="check">*/
const userContainerDiv = document.querySelector("#user-container");

/*
<div id="login-container" class="float-login form">
  <header>Login</header>
  <form action="#">
    <input type="text" placeholder="Enter your UserName">
    <input type="password" placeholder="Enter your password">
    <input type="button" class="button" value="Login">
  </form>    
</div>*/
const loginContainerDiv = document.querySelector("#login-container");

function GenerateLoginContainer() {
    let loginDiv = document.createElement("div");
    loginDiv.id = "login-container";
    loginDiv.className = "float-login form";
    // Create the username input field and label
    let usernameInput = document.createElement('input');
    usernameInput.type = 'text';
    usernameInput.id = 'username-input';

    let usernameInputLabel = document.createElement('label');
    usernameInputLabel.textContent = "Username";

    // Create the password input field and label
    let passwordInput = document.createElement('input');
    passwordInput.type = 'password';
    passwordInput.id = 'password-input';

    let passwordInputLabel = document.createElement('label');
    passwordInputLabel.textContent = "Password";

    // Create the login button
    let loginButton = document.createElement('button');
    loginButton.textContent = "Login";

    // Append the login container to the main user container
    userContainerDiv.appendChild(loginDiv);

    // Append the username and password fields and labels to the login container
    loginDiv.appendChild(usernameInputLabel);
    loginDiv.appendChild(usernameInput);
    loginDiv.appendChild(passwordInputLabel);
    loginDiv.appendChild(passwordInput);
    loginDiv.appendChild(loginButton);

    // Add an event listener to the login button to handle login
    loginButton.addEventListener("click", GetLoginInformation);
}

function TeardownLoginContainer() {
  // Find the login container
  let loginDiv = document.querySelector("#login-container");

  // If the login container exists, remove all its children
  if (loginDiv != null) {
      while (loginDiv.firstChild) {
          loginDiv.firstChild.remove();
      }
  }
}

function GetLoginInformation() {
  let username = document.querySelector("#username-input").value;
  let password = document.querySelector("#password-input").value;

  // Call the function to log in the user
  LoginUser(username, password);
}

async function LoginUser(username, password) {
  try {
      let response = await fetch(`${BASE_URL}/Users/login`, {
          method: "POST",
          headers: {
              'Content-Type': "application/json" // Corrected the content type to 'application/json'
          },
          body: JSON.stringify({
              "Username": username, 
              "Password": password
          })
      });

      let data = await response.json();
      current_user = data;

      console.log(current_user);
      TeardownLoginContainer()
      //generateHomePageContainer(data);
      // console.log(data);
  } catch (e) {
      console.error('Error logging in:', e); // Added error logging
  }
}
GenerateLoginContainer();

/*
    <div id="registration-container" class="float-registration form">
      <header>Signup</header>
      <form action="#">
        <input type="text" placeholder="Enter your First Name">
        <input type="password" placeholder="Enter Your Last Name">
        <input type="password" placeholder="Enter your UserName">
        <input type="password" placeholder="Enter your Password">
        <input type="button" class="button" value="Signup">
      </form>
  */
const registrationContainerDiv = document.querySelector("#registration-container");
function GenerateRegistrationContainer(){

}

const homepageContainer = document.querySelector("#homepage-container");
function GenerateInventoryContainer(){

}

function GeneratePurchaseContainer(){

}

function GenerateMenuContainer(){
  
}

const purchaseHistoryContainer = document.querySelector("#purchaseHistory-container");
function GeneratePurchaseHistoryContainer(){

}
