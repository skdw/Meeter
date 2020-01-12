window.onload = function init () {

    var groupform = document.getElementById("groupform");
    groupform.action = "/api/meeter/groups";
    groupform.method = "post";

    var groupname_label = document.createElement("label");
    groupname_label.className = "formFieldName";
    groupname_label.innerHTML = "Group name";
    groupname_label.htmlFor = "group_name";

    var groupname_input = document.createElement("input");
    groupname_input.id = "group_name";
    groupname_input.className = "formFieldInput";
    groupname_input.type = "text";
    groupname_input.name = "groupname";

    var namediv = document.createElement("p");
    namediv.className = "formRow";
    namediv.appendChild(groupname_label);
    namediv.appendChild(groupname_input);
    groupform.appendChild(namediv);

    var userdiv = document.createElement("fieldset");
    userdiv.id = "userdiv";
    groupform.appendChild(userdiv);

    var legend = document.createElement("legend");
    legend.innerText = "Add users to the group:";
    userdiv.appendChild(legend);

    fetch('api/Meeter/users')
        .then(response => response.json())
        .then(json => json.map(appendUser));

    function appendUser(userData) {

        var userp = document.createElement("p");
        userp.className = "formRow";

        var user_label = document.createElement("label");
        user_label.className = "formFieldName";
        user_label.htmlFor = "user" + userData.id;
        user_label.innerHTML = userData.firstName + " " + userData.lastName;

        var user = document.createElement("input");
        user.id = "user" + userData.id;
        user.type = "checkbox";
        user.name = "user";
        user.value = userData.id;
        userp.appendChild(user);
        userp.appendChild(user_label);
        userdiv.appendChild(userp);

        //console.log(userData);

    };

    var submit_button = document.createElement("button");
    submit_button.type = "submit";
    submit_button.innerHTML = "Create group";
    groupform.appendChild(submit_button);
};