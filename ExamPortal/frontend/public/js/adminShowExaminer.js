function loadSetupExaminerPage(data){
  $('#performance').empty()
  $.get('./adminSetupExaminer.html',function(template){
    var rendered = Mustache.render(template,{data:data})
    $('#targetPage').html(rendered)
  })
}


$(document).ready(function () {
  $.ajax("http://127.0.0.1:3000/examiner", {
    type: "GET",
    dataType: "json",
    contentType: "application/json",
    success: function (recent) {
      display(recent);
      // console.log(recent);
    },
    error: function () {
      console.log("Something went wrong");
    }

  });

  function display(recent) {
    const displaytemplate = document.querySelector("#index-template").innerHTML;
    const html = Mustache.render(displaytemplate, { data: recent })
    const performance = document.querySelector("#performance");
    performance.insertAdjacentHTML("beforeend", html)
  }


  $(document).on('click', '.deleteButton', function () {
    let id = $(this).attr('id')
    //console.log(id);
    $.ajax("http://127.0.0.1:3000/examiner", {
      type: "DELETE",
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(
        {
          "_id": id
        }
      ),
      success: function (recent) {

        //display(recent); 
        location.reload();
        console.log("user deleted");
        //window.location.replace("adminHome.html")
      },
      error: function () {
        console.log("Something went wrong");
      }

    })
  })

  $(document).on('click', '.updateButton', function () {
    let id = $(this).attr('id')
    $.ajax("http://127.0.0.1:3000/examiner/id", {
      type: "GET",
      dataType: "json",
      contentType: "application/json",
      data: {
        "id": id
      },
      success: function (recent) {
        loadSetupExaminerPage(recent)
      },
      error: function () {
        console.log("Something went wrong");
      }

    })
  })
})