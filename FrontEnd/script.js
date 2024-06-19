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

  const loginErrorMessage = document.createElement("p");
  loginErrorMessage.id = "login-error-message";
  loginErrorMessage.style.color = "red";
  loginErrorMessage.style.fontWeight = "bold";
  loginErrorMessage.style.paddingTop = "15px";

  // Append the username and password fields and labels to the login container
  loginDiv.appendChild(userNameInputLabel);
  loginDiv.appendChild(userNameInput);
  loginDiv.appendChild(passwordInputLabel);
  loginDiv.appendChild(passwordInput);
  loginDiv.appendChild(loginButton);
  loginDiv.appendChild(loginErrorMessage);

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

//  Tear down user container
function TeardownUserContainer() {
  // Find the user container
  let userDiv = document.querySelector("#user-container");

  // If the user container exists, remove all its children
  if (userDiv != null) {
    while (userDiv.firstChild) {
      userDiv.firstChild.remove();
    }
  }
}


async function GetLoginInformation() {
  let userName = document.querySelector("#userName-input").value;
  let password = document.querySelector("#password-input").value;

  // Call the function to log in the user
  try {
    await LoginUser(userName, password);
  } catch (e) {
    const loginErrorMessage = document.querySelector("#login-error-message");
    loginErrorMessage.textContent = e.message;
  }
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
    TeardownRegistrationContainer()

    //Tear down User Container
    TeardownUserContainer()

    //Generate Purchase container
    GeneratePurchaseContainer();



    //generateHomePageContainer(data);
    // console.log(data);
  } catch (e) {
    console.error('Error logging in:', e); // Added error logging
    throw new Error('Error logging in: incorrect username password combination');
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

function TeardownRegistrationContainer() {
  let registrationDiv = document.querySelector("#registration-container");

  // If the login container exists, remove all its children
  if (registrationDiv != null) {
    //while (registrationDiv.firstChild) {
    //registrationDiv.firstChild.remove();
    //}
    registrationDiv.remove();
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
    TeardownRegistrationContainer()
    //generateHomePageContainer(data);
    console.log(data);
  } catch (e) {
    console.error('Registration Error:', e); // Added error logging
  }
}

GenerateRegistrationContainer()

//List of plants
async function GetAllPlants() {
  try {
    let response = await fetch(`${BASE_URL}/Plants`, {
      method: "GET",
      headers: {
        'Content-Type': "application/json"
      },
    });


    const plants = await response.json();
    return plants
  } catch (e) {
    console.error("Error getting plants:", e);
  }
}





const homepageContainer = document.querySelector("#homepage-container");
async function GeneratePurchaseContainer() {
  //TeardownPurchaseContainer()
  TeardownPurchaseHistoryContainer()

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

  //make call to get plants
  const plants = await GetAllPlants();



  dropdown.add(defaultOption);
  dropdown.selectedIndex = 0;
  console.log(plants);
  //get options 
  for (let i = 0; i < plants.length; i++) {
    option = document.createElement('option');
    option.text = plants[i].plantName;
    option.value = plants[i].plantId;
    dropdown.add(option);
  }

  //Purchase button and message and click
  const messageElement = document.createElement("p");
  const buyButton = document.createElement("button");
  buyButton.textContent = "Purchase";
  buyButton.style.marginLeft = "10px";
  buyButton.style.padding = "10px";
  buyButton.style.backgroundColor = "white";
  buyButton.style.fontWeight = "bold";
  buyButton.addEventListener("click", async function () {
    const plantId = parseInt(dropdown.value);
    const quantity = 1;
    const plant = plants.find(plant => plant.plantId == plantId);
    const price = plant.price;
    const userId = current_user.userId;
    const purchaseHistory = await BuyPlant(userId, plantId, quantity, price);
    const message = `You have purchased ${quantity} ${plant.plantName} for $${purchaseHistory.price}.00`;
    messageElement.textContent = message;
  });


  //keys match the plant names in database - add link to image when plants added to database
  const plantImages = {
    "Casa Blanca Lily": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaNrKV8XQjT4zN7ZR92NzY5nJWLg2_fy6Ycg&s",
    "Stargazer Lily": "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcT9g6npvWboQc6OMxuSAdNaIwJPoq--nSnnTQtwJnH94pGhCrvDLp85DyTHyE6HbLgVSbkxMbBP0h79tPlP25AYbhyx4C1DCQi0SpZ9M0EE&usqp=CAc",
    "Sarah Bernhardt Peony": "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQHFGtvgRKtk9Cjranm6Th7sDCxZKT2920I9zWKCu1T4AJr9uV87YU_IrQvuvL3QCndeVHF5O-QnoqpGiK_sQf3fjcmRnsraS3G7clVGME&usqp=CAc",
    "Elsa Sass Peony": "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQTXngv3_j6UbbDQaPwU2qgtwVFBpu9M4XVSyorHEsc3OYVRUrrW116hpMJNTBEPJLIAC4clD-0CcDi-eivj2n7VtktYh3RqvA7mVCryvmn&usqp=CAc",
    "Purple Bearded Iris" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSSeb6D4Th4E6aunwxQOPLrDSInBPcLXTGAGQ&usqp=CAU",
    "Gardenia" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9QTHpskUGn_GTHoQnrBzKAJxVdiAL_qHH_A&usqp=CAU",
    "ZZ Plant" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkWDsUlDh-7tGToc9DJ16ccTHgL6ECDqDfiNOrWFO-t_aZlqGpyjwWcxP9bVpI1PM7hLI&usqp=CAU",
    "Bamboo" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSf-iStIsxpw2cr91-iVbr0Ye9vGyxfb3LSA&usqp=CAU",
    "Purple Orchid" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0geQo3_J_dHHKOejFR2E-F961lBdBTlOqaQ&usqp=CAU",
    "Fiddle-Leaf Fig" : "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKwUHQ6Y6yJc0NpFYbUiogHb1gcxD59WE7bQ&usqp=CAU",
  }

  const plantListDiv = document.createElement('div');
  //Header for container and builds list of plants pulled from API
  let plantsHeader = document.createElement("h1");
  plantsHeader.textContent = "Plants";
  plantListDiv.appendChild(plantsHeader);
  const plantListUnorderedList = document.createElement('ul');
  plantListDiv.appendChild(plantListUnorderedList);
  for (i = 0; i < plants.length; i++) {
    let plant = plants[i];
    let plantListItem = document.createElement('li');
    const plantName = document.createElement('h3');
    plantName.textContent = `${plant.plantName}`
    const price = document.createElement('p');
    price.textContent = `$${plant.price}.00`

    const plantImage = document.createElement('img');
    plantImage.src = plantImages[plant.plantName];
    plantImage.width = 200;
    plantImage.height = 200;


    plantListItem.appendChild(plantImage);
    plantListItem.appendChild(plantName);
    plantListItem.appendChild(price);
    plantListUnorderedList.appendChild(plantListItem);
  }

  homepageContainer.appendChild(plantListDiv);
  //Purchase button and message
  homepageContainer.appendChild(purchaseContainerDiv);
  purchaseContainerDiv.appendChild(purchaseHeader);
  purchaseContainerDiv.appendChild(purchaseDescription);
  purchaseContainerDiv.appendChild(dropdown);
  purchaseContainerDiv.appendChild(buyButton);
  purchaseContainerDiv.appendChild(messageElement);


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
}

function TeardownPurchaseContainer(){

  if (purchaseContainer != null) {
    while (purchaseContainer.firstChild) {
      purchaseContainer.firstChild.remove();

    }
  }

}

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

function TeardownHomepageContainer() {
  let homepageDiv = document.querySelector("#homepage-container");

  // If the homepage container exists, remove all its children
  if (homepageDiv != null) {
    while (homepageDiv.firstChild) {
      homepageDiv.firstChild.remove();
    }
  }
}

async function OpenPurchaseHistory() {
  if (JSON.stringify(current_user) == '{}') {
    // If we're not logged in, don't do anything
    return;
  }
  // Tear down current container (purchase container)
  TeardownHomepageContainer();
  // Generate purchase history container
  await GeneratePurchaseHistoryContainer();
}

const purchaseHistoryContainer = document.querySelector("#purchaseHistory-container");
async function GeneratePurchaseHistoryContainer() {
  TeardownPurchaseHistoryContainer()
  const purchaseHistories = await GetPurchaseHistories();
  //filters history by user
  const purchaseHistoryForUser = purchaseHistories.filter(purchaseHistory => purchaseHistory.userId === current_user.userId);

  //Chante code for table
  //creates a <table> element and a d <tbody> element
  const tbl = document.createElement("table");
  const tblBody = document.createElement("tbody");

  //creating all cells
  for (let i = 0; i < purchaseHistoryForUser.length; i++) {
    //create a table row
    const row = document.createElement("tr");
    const purchaseHistory = purchaseHistoryForUser[i];
    //const data = Object.entries(purchaseHistory);
    const plant = await GetPlantById(purchaseHistory.plantId);
    const data = [
      ["Plant Name", plant.plantName],
      ["Quantity", purchaseHistory.quantity],
      ["Purchase Price", purchaseHistory.price],

    ]
    for (let j = 0; j < data.length; j++) {
      //create a <td> element and a text node,
      // make the text node the contents of the <td>, 
      //and put the <td> at the end of the table row
      const cell = document.createElement("td");
      const cellText = document.createTextNode(`${data[j][0]} - ${data[j][1]}`);
      cell.appendChild(cellText);
      row.appendChild(cell);
    }
    //add the row to the end of the table body
    tblBody.appendChild(row);
  }
  const headerElement = document.createElement("h1");
  headerElement.textContent = "Your Purchase History";
  purchaseHistoryContainer.appendChild(headerElement);
  purchaseHistoryContainer.appendChild(tbl);
  //put the <tbody> in the <table>
  tbl.appendChild(tblBody);
  //appends <table> into <body>
  homepageContainer.appendChild(purchaseHistoryContainer);
  //sets the border attribute of tbl to 2;
  tbl.setAttribute("border", "2");






}

//GeneratePurchaseHistoryContainer();


async function GetPurchaseHistories() {
  try {
    let response = await fetch(`${BASE_URL}/PurchaseHistories`, {
      method: "GET",
      headers: {
        'Content-Type': "application/json"
      },
    });


    const purchaseHistories = await response.json();
    return purchaseHistories
  } catch (e) {
    console.error("Error getting purchase histories:", e);
  }
}

async function GetPlantById(plantId) {
  try {
    let response = await fetch(`${BASE_URL}/Plants/${plantId}`, {
      method: "GET",
      headers: {
        'Content-Type': "application/json"
      },
    });


    const plant = await response.json();
    return plant
  } catch (e) {
    console.error("Error getting plant:", e);
  }
}

async function BuyPlant(userId, plantId, quantity, price) {
  try {
    let response = await fetch(`${BASE_URL}/PurchaseHistories/`, {
      method: "POST",
      headers: {
        'Content-Type': "application/json"
      },
      body: JSON.stringify({
        "userId": userId,
        "plantId": plantId,
        "quantity": quantity,
        "price": price
      }),
    });


    const purchaseHistory = await response.json();
    return purchaseHistory
  } catch (e) {
    console.error("Error buying plant:", e);
  }


}
function TeardownPurchaseHistoryContainer() {


  // If the purchase container is not null, remove all its children
  if (purchaseHistoryContainer != null) {
    while (purchaseHistoryContainer.firstChild) {
      purchaseHistoryContainer.firstChild.remove();

    }
  }
}
function RedisplayPurchaseContainer(){
  if (JSON.stringify(current_user) == '{}') {
    // If we're not logged in, don't do anything
    return;
  }
  TeardownHomepageContainer()
  //TeardownPurchaseContainer()
  TeardownPurchaseHistoryContainer()
  GeneratePurchaseContainer()
}

function LogOutUser() {
  if (JSON.stringify(current_user) == '{}') {
    // If we're not logged in, don't do anything
    return;
  }
  current_user = {};
  TeardownHomepageContainer()
  GenerateLoginContainer()
  GenerateRegistrationContainer()
}
















