//$("#sortable").sortable();
$(document).ready(function(){
    getAllTodo();
});

$('#addTodo').on('keypress',function (e) {
    e.preventDefault;
    if (e.which == 13) {
        if($(this).val() != ''){
            var todo = $(this).val();
            createTodo(todo);
        }
    }
});

$('#btnAdd').on('click',function (e) {
    e.preventDefault;
    if($('#addTodo').val() != ''){
        var todo = $('#addTodo').val();
        createTodo(todo);
    }
});

$(document).on("click","label[class='form-check-label']", function(){
    if($(this).hasClass('done'))
        $(this).removeClass('done');
    else
        $(this).addClass('done');    
});

$(document).on("click","span[class='todo-destroy']", function(){
    var id = $(this).attr('data-id');
    deleteTodo(id);
});


function createTodo(todo){
    console.log(todo);
    $.post("/todo?format=json",
    {
        Text: todo,
        Done: false
    },
    function(data){
        getAllTodo();
    });
}

function getAllTodo(){
    $.get("/todo?format=json",
    function(data){
        console.log(data);
        $('#sortable').empty();
        for (var i = 0, len = data.length; i < len; i++) {
            var markup = '<li class="ui-state-default"><div id="showing" class="form-check"><label class="form-check-label"><input class="form-check-input" type="checkbox" value="'+ data[i].id +'" />'+ data[i].text +'</label><span class="todo-destroy" data-id="'+ data[i].id +'"><i class="fa fa-times" aria-hidden="true"></i></span></div></li>';
            $('#sortable').append(markup);
        }
        $('#add-todo').val('');
        countTodos();
    });
}

function deleteTodo(id){
    console.log(id);
    $.ajax({
        url: '/todo?format=json&Id='+ id,
        type: 'DELETE',
        success: function(data) {
            getAllTodo();
        }
    });
}

function countTodos(){
    var count = $("#sortable li").length;
    $('.count-todos').html(count);
}