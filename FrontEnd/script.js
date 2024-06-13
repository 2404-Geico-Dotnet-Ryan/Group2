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

  //Label
  let loginHeader = document.createElement("h2");
  loginHeader.textContent = "Login";
  loginDiv.appendChild(loginHeader);
  // Create the username input field and label
  let userNameInput = document.createElement('input');
  userNameInput.type = 'text';
  userNameInput.id = 'userName-input';

  let userNameInputLabel = document.createElement('label');
  userNameInputLabel.textContent = "Username";

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
  loginDiv.appendChild(userNameInputLabel);
  loginDiv.appendChild(userNameInput);
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
  let userName = document.querySelector("#userName-input").value;
  let password = document.querySelector("#password-input").value;

  // Call the function to log in the user
  LoginUser(userName, password);
}

async function LoginUser(userName, password) {
  try {
    let response = await fetch(`${BASE_URL}/Users/login`, {
      method: "POST",
      headers: {
        'Content-Type': "application/json" // Corrected the content type to 'application/json'
      },
      body: JSON.stringify({
        "UserName": userName,
        "Password": password
      })
    });

    let data = await response.json();
    current_user = data;

    console.log(current_user);
    TeardownLoginContainer()
    GenerateTeardownRegistrationContainer()
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

function GenerateRegistrationContainer() {

  let registrationDiv = document.createElement("div");
  registrationDiv.id = "registration-container";
  registrationDiv.className = "float-registration form";

  //Label
  let registrationHeader = document.createElement("h2");
  registrationHeader.textContent = "Register";
  registrationDiv.appendChild(registrationHeader);

  // Create the username input field and label
  let userNameInput = document.createElement('input');
  userNameInput.type = 'text';
  userNameInput.id = 'registration-userName-input';

  let userNameInputLabel = document.createElement('label');
  userNameInputLabel.textContent = "UserName";

  // Create the password input field and label
  let passwordInput = document.createElement('input');
  passwordInput.type = 'password';
  passwordInput.id = 'registration-password-input';

  let passwordInputLabel = document.createElement('label');
  passwordInputLabel.textContent = "Password";

  // Create the first name input field and label
  let firstNameInput = document.createElement('input');
  firstNameInput.type = 'text';
  firstNameInput.id = 'firstName-input';

  let firstNameInputLabel = document.createElement('label');
  firstNameInputLabel.textContent = "First Name";

  // Create the last name input field and label
  let lastNameInput = document.createElement('input');
  lastNameInput.type = 'text';
  lastNameInput.id = 'lastName-input';

  let lastNameInputLabel = document.createElement('label');
  lastNameInputLabel.textContent = "Last Name";

  // Create the submit button
  let submitButton = document.createElement('button');
  submitButton.textContent = "Submit";

  // Append the registration container to the main user container
  userContainerDiv.appendChild(registrationDiv);

  // Append the first name, last name, username and password fields and labels to the registration container
  registrationDiv.appendChild(userNameInputLabel);
  registrationDiv.appendChild(userNameInput);
  registrationDiv.appendChild(passwordInputLabel);
  registrationDiv.appendChild(passwordInput);
  registrationDiv.appendChild(firstNameInputLabel);
  registrationDiv.appendChild(firstNameInput);
  registrationDiv.appendChild(lastNameInputLabel);
  registrationDiv.appendChild(lastNameInput);
  registrationDiv.appendChild(submitButton);

  // Add an event listener to the submit button to handle login
  submitButton.addEventListener("click", CreateNewUserInformation);
}

function GenerateTeardownRegistrationContainer() {
  let registrationDiv = document.querySelector("#registration-container");

  // If the login container exists, remove all its children
  if (registrationDiv != null) {
    while (registrationDiv.firstChild) {
      registrationDiv.firstChild.remove();
    }
  }
}

function CreateNewUserInformation() {
  let userName = document.querySelector("#registration-userName-input").value;
  let password = document.querySelector("#registration-password-input").value;
  let firstName = document.querySelector("#firstName-input").value;
  let lastName = document.querySelector("#lastName-input").value;

  // Call the function to log in the user
  RegisterUser(userName, password, firstName, lastName);
}

async function RegisterUser(userName, password, firstName, lastName) {
  try {
    let response = await fetch(`${BASE_URL}/Users`, {
      method: "POST",
      headers: {
        'Content-Type': "application/json" // Corrected the content type to 'application/json'
      },
      body: JSON.stringify({
        "userId": 0,
        "userName": userName,
        "password": password,
        "firstName": firstName,
        "lastName": lastName
      })
    });

    let data = await response.json();
    current_user = data;

    console.log(current_user);
    GenerateTeardownRegistrationContainer()
    //generateHomePageContainer(data);
    console.log(data);
  } catch (e) {
    console.error('Registration Error:', e); // Added error logging
  }
}

GenerateRegistrationContainer()

const homepageContainer = document.querySelector("#homepage-container");
function GeneratePurchaseContainer() {

  let purchaseContainerDiv = document.createElement("div");

  purchaseContainerDiv.id = "Purchase-container";
  purchaseContainerDiv.className = "float-Purchase list";
  let purchaseHeader = document.createElement("h3");
  purchaseHeader.textContent = "Checkout";
  let purchaseDescription = document.createElement("p");
  purchaseDescription.textContent = "Please select which plant you'd like to purchase from the Plant List below.";

  
  let dropdown = document.createElement("select");
  dropdown.length = 0;


  let defaultOption = document.createElement("option");
  defaultOption.text = 'Choose Plant';

  dropdown.add(defaultOption);
  dropdown.selectedIndex = 0;

  homepageContainer.appendChild(purchaseContainerDiv);
  purchaseContainerDiv.appendChild(purchaseHeader);
  purchaseContainerDiv.appendChild(purchaseDescription);
  purchaseContainerDiv.appendChild(dropdown);

  // fetch(url)  
  //   .then(  
  //     function(response) {  
  //       if (response.status !== 200) {  
  //         console.warn('Looks like there was a problem. Status Code: ', 
  //           response.status);  
  //         return;  
  //       }

  //       // Examine the text in the response  
  //       response.json().then(function(data) {  
  //         let option;

  //         for (let i = 0; i < data.length; i++) {
  //           option = document.createElement('option');
  //           option.text = data[i].name;
  //           option.value = data[i].abbreviation;
  //           dropdown.add(option);
  //         }    
  //       });  
  //   }  
  // )  
  // .catch(function(err) {  
  //   console.error('Fetch Error -', err);  
  // });
  purchaseContainerDiv.appendChild(dropdown);
}
GeneratePurchaseContainer();

//   <div id="Purchase-container"> </div>
//   <div> <div id="Purchase-container" class="float-Purchase list">
//     <header>Checkout</header>
//     <p>Please select which plant you'd like to purchase from the Plant List below. </p>
//   <body>
//     <div class="col-md-4">
//     <form>
//     <h4>Plant List</h4>
//     <select class="form-control"  id='firstList' name='firstList' onClick="getPlants()">
//     </select>
//     <form action="#"></form>
//     <input type="button" class="button" value="Purchase">

// </div>




function GenerateMenuContainer() {

}

const purchaseHistoryContainer = document.querySelector("#purchaseHistory-container");
function GeneratePurchaseHistoryContainer() {

}
