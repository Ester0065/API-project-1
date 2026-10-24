const postdata = async () => {
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const email = document.querySelector("#email").value
    const password = document.querySelector("#password").value

    const user = {
        firstName,
        lastName,
        email,
        password
    };

    try {
        const respone = await fetch(`api/Users`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });

       
        if (respone.ok) {
            const CurrentUser = await respone.json();
            alert("נרשמת בהצלחה")
        }
        else {
            throw Error("error")
        }
    }
    catch (e) {
        alert(e.message)
    }


}

const getUser = async () => {
   const email=document.querySelector("#logemail").value
    const password=document.querySelector("#logpassword").value

    const loguser={
        email,
        password
    }

    try {
       
        const respone = await fetch(`api/Users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loguser)
        });

        
        if (!respone.ok)
            throw Error("the user not connected")
        else {
            const CurrentUser = await respone.json();
            alert("your login was succsess")
            sessionStorage.setItem("CurrentUser",JSON.stringify(CurrentUser))
            window.location.href="UserDetails.html"

                // a = document.querySelector(".a");
                // a.style.display = "none";
                // succses = document.querySelector(".succses");
                // succses.textContent = succses.textContent + " " + (await response.json()).firstName;
                // succses.style.display = "block";
        }
                
    }
    catch (e) {
        alert(e.message)
    }
}


const newUser=()=>{
    const sign=document.querySelector(".sign")
    sign.style.display="block";
    sign.style.display="grid"; 

}