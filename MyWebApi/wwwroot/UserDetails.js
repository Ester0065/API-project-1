const title = document.querySelector(".title")
// const NameUser = JSON.parse(User).name
// const IdUser = JSON.parse(User).IdUser
const updateDetails=document.querySelector(".updateDetails")
const details=document.querySelector(".details")


const User = sessionStorage.getItem("CurrentUser")
const nameUser1 = JSON.parse(User).firstName;
const lastName1 = JSON.parse(User).lastName;
const email1 = JSON.parse(User).email;
const password1 = JSON.parse(User).password;
const id = JSON.parse(User).id;

title.textContent = title.textContent+ " "+ nameUser1

const writeTheUser =  () => {
    const fname2 = document.querySelector("#firstName")
    const lname2 = document.querySelector("#lastName")
    const email2 = document.querySelector("#email")
    const password2 = document.querySelector("#password")

    fname2.value=nameUser1
    lname2.value=lastName1
    email2.value=email1
    password2.value=password1

    details.style.display="block"
}

const put = async() => {
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value
    
    const user = {  
        id:id,
        firstName,
        lastName,
        email,
        password

    };

    try {

        const respone = await fetch(`api/Users/${id}`, {
            method: 'PUT',
            headers: {
               'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

    }
        catch (e) {
            alert(e.message)
        }
}

