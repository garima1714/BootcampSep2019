$(document).ready(function() {
    var flag= false
    $("#signUpSubmit").click((event) => {
        event.preventDefault()
        fname = $("#firstName").val()
        lname = $("#lastName").val()
        name = fname + " " + lname
        email = $("#inputEmail").val()
        phoneNumber = $("#phoneNumber").val()

        password = $("#inputPassword").val()

        confirmPassword = $("#cnfPassword").val()

        accountType = $("#accountType").val()

        if (password != confirmPassword)
            return alert("Confirm Password does not match")
        if (fname === "") {
            return alert("Please enter First Name")
        } else {
            fname = true
            var regex = /^[a-zA-Z\s]+$/;
            if (regex.test(fname) === false) {
                $("#firstName").innerHTML = ""
                alert("Please enter a valid first name");
            } else {
                fname = true;
            }
        }
        if (lname === "") {
            alert("Please enter your last name");
        } else {
            lname = true
            var regex = /^[a-zA-Z\s]+$/;
            if (regex.test(lname) === false) {
                alert("Please enter a valid last name");
            } else {
                lname = true;
            }
        }
        if (phoneNumber == "") {
            alert("Please enter your mobile number");
        } else {

            var regex = /^[1-9]\d{9}$/;
            if (regex.test(phoneNumber) === false) {
                alert("Please enter a valid 10 digit mobile number");

            } else {
                flag = true
                phoneNumber = $("#phoneNumber").val() ;
            }
        }

        if ((fname && lname && email && password && flag) == true) {
            let signUpData = true
            alert("Your SignUp has been successful")
        } else {
            signUpData = false
            alert("Your data is not valid")
        }
        $.ajax("http://localhost:3000/signUp", {
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            beforeSend: function() {
                $('.main').animate({ opacity: 0.6 })
                $('.mod').fadeIn()
                $('.spinner').show()
            },
            data: JSON.stringify({
                "name": name,
                "email": email,
                "phoneNumber": phoneNumber,
                "password": password,
                "accountType": "Student"
            }),
            success: function(data, status) {
                $(location).attr('href', '../views/login.html')
            },
            error: function(data, error) {
                 console.log(error +" "+ "error occurred");
            }
        })
    })

})