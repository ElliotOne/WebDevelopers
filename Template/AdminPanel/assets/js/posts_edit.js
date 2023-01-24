//Problemes : 
//"save" not working


tinymce.init({
    selector: '#textEditor', // change this value according to your HTML
    setup: function (editor) {
        editor.ui.registry.addContextToolbar('imagealignment', {
            predicate: function (node) {
                return node.nodeName.toLowerCase() === 'img'
            },
            items: 'alignleft aligncenter alignright',
            position: 'node',
            scope: 'node'
        });

        editor.ui.registry.addContextToolbar('textselection', {
            predicate: function (node) {
                return !editor.selection.isCollapsed();
            },
            items: 'bold italic | blockquote',
            position: 'selection',
            scope: 'node'
        });
    },
    plugin: 'a_tinymce_plugin',
    language: 'fa_IR',
    dir: 'rtl',
    a_plugin_option: true,
    a_configuration_option: 400,
    skin: "oxide-dark",
    plugins: ["table anchor autolink charmap code codesample legacyoutput image",
        "imagetools media tabfocus lists advlist directionality help nonbreaking insertdatetime save",
        "print searchreplace quickbars visualchars paste pagebreak preview emoticons hr fullscreen",
        "autosave fullpage link visualblocks wordcount"
    ],
    menubar: "table insert tools file edit view",
    toolbar: ["table anchor charmap code codesample image media numlist bullist ltr rtl",
        "help nonbreaking insertdatetime save print searchreplace visualchars paste pagebreak preview", 
        "emoticons forecolor backcolor fullscreen restoredraft fullpage link visualblocks wordcount | bold italic"
        ," | alignleft aligncenter alignright | undo redo outdent indent | formatselect fontselect fontsizeselect",
    ],
    table_cell_class_list: [{
            title: 'None',
            value: ''
        },
        {
            title: 'Dog',
            value: 'dog'
        },
        {
            title: 'Cat',
            value: 'cat'
        }
    ],
    height: 500,
    imagetools_cors_hosts: ['mydomain.com', 'otherdomain.com'],
    imagetools_proxy: 'proxy.php',
    imagetools_toolbar: 'rotateleft rotateright | flipv fliph | editimage imageoptions',
    tabfocus_elements: ":prev,:next",
    insertdatetime_formats: ["%H:%M:%S", "%Y-%m-%d", "%I:%M:%S %p", "%D"],
    save_enablewhendirty: true,

    block_formats: 'Paragraph=p;Header 1=h1;Header 2=h2;Header 3=h3',
    font_formats: 'Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n',
    
    // style_formats: 
    //     { title: 'Bold text', inline: 'strong' },
    //     { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
    //     { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
    //     { title: 'Badge', inline: 'span', styles: { display: 'inline-block', border: '1px solid #2276d2', 'border-radius': '5px', padding: '2px 5px', margin: '0 2px', color: '#2276d2' } },
    //     { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
    //   ],
    //   formats: {
    //     alignleft: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'left' },
    //     aligncenter: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'center' },
    //     alignright: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'right' },
    //     alignfull: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'full' },
    //     bold: { inline: 'span', 'classes': 'bold' },
    //     italic: { inline: 'span', 'classes': 'italic' },
    //     underline: { inline: 'span', 'classes': 'underline', exact: true },
    //     strikethrough: { inline: 'del' },
    //     customformat: { inline: 'span', styles: { color: '#00ff00', fontSize: '20px' }, attributes: { title: 'My custom format' }, classes: 'example1' }
    //   }
   
});




document.getElementById("btnImgUpload").addEventListener("click",function(e){
    e.preventDefault();
})


window.addEventListener("load",function(e){
    
    //================ If Clicke "Add Button" in posts page ==============
    let isAddClicked = true;
    if(isAddClicked){
        document.getElementById("btnEdit").remove();
        document.getElementById("btnDelete").remove();
    }else{
        document.getElementById("btnAdd").remove();
    }
})