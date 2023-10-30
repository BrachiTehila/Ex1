
const register = async () => {
    const user = {
        email: document.getElementById("email").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstN").value,
        lastName: document.getElementById("lastN").value
    }

    try {
        const responsePost = await fetch('api/User', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })|AQ                                                                                                                                   
        if (!responsePost.ok)
            alert(`${user.firstName} didnt register`)
        else { 
        const data = await responsePost.json()
            alert(`${data.firstName} registered succesfuly`)
        }
    }
    catch (error) { alert(error) }
}

const login = async () => {
    
    const email = document.getElementById("emailLogin").value
    const password = document.getElementById("passwordLogin").value

    try {
        const responseGet = await fetch(`api/User?email=${email}&password=${password}`)
        if (!responseGet.ok)
            alert("not login")
        else {
            const data = await responseGet.json()
            sessionStorage.setItem("user", JSON.stringify(data))
            window.location.href = "./update.html"
        }
    }
    catch (error) { alert(error) }
}


const update = async () => {
    const userToUpdate = {
        email: document.getElementById("emailUpdate").value,
        password: document.getElementById("passwordUpdate").value,
        firstName: document.getElementById("firstNameUpdate").value,
        lastName: document.getElementById("lastNameUpdate").value
    }
    const id = JSON.parse(sessionStorage.getItem("user")).id
    try {
        const responsePost = await fetch(`api/User/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(userToUpdate)
        })
        if (!responsePost.ok)
            alert("didnt update")
        else {
            const data = await responsePost.json()
            alert(`user ${data.id} update`)
        }
    } catch (error) { alert(error) }






    const checkPassword = async () => {

        var strength = {
            0: "Worst",
            1: "Bad",
            2: "Weak",
            3: "Good",
            4: "Strong"
        }

        password = document.getElementById("level").value;
        meter= document.getElementById("password");

        try {
            const response = await fetch('api/User/check', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(password)
            })
            if (!response.ok)
                alert('enter another password')
            else {
                const strengthLevel = await response.json()
                if (strengthLevel <= 2) 
                    alert("weak password")
                meter.value = strengthLevel
            }
             }
        catch (error) { alert(error) }
    }
}

