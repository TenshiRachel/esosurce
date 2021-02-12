<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="addProject.aspx.cs" Inherits="Esource.Views.profile.addProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="submit-projects">
        <div class="card">
            <div class="card-body">
                <div class="row justify-content-center mx-auto h-100">
                    <div class="col-10 form-group p-0 align-self-center mt-5">

                        <label for="title" class="h3">Title of Project </label>
                        <input runat="server" type="text" class="form-control mb-4" name="title" id="title"
                            aria-describedby="helpId" placeholder="Project Title" required>


                        <h3>Cover Image</h3>
                        <div class="filepreview">
                            <div class="wrapper card card-body view overlay text-center z-depth-2">
                                <div class="mask rgba-black-slight"></div>
                                <div class="preview deep-purple accent-3">
                                    <img src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>" id="poster" />
                                    <div id="fileMask" class="infos d-none">
                                        <div class="infos-inner">
                                            <p id="maskText" class="filename"></p>
                                            <a class="btn btn-sm btn-success">Change file</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-text">
                                    <i class="fas fa-5x fa-image"></i>
                                    <p class="font-weight-bolder">No Image Uploaded</p>
                                </div>
                                <div class="custom-file">
                                    <asp:FileUpload runat="server" ID="upPoster" />
                                </div>
                            </div>
                        </div>
                        <div class="text-center">
                            <a id="fileRemove" class="btn btn-danger btn-sm text-center d-none" style="z-index: 3;">Remove file</a>
                        </div>
                        <p class="text-muted mt-2">
                            This will be the cover image that will be shown in your profile
                        </p>

                        <h3>Content</h3>
                        <div class="form-group">
                            <div class="md-form md-outline">
                                <label for="tbcontent">Content</label>
                                <textarea runat="server" id="tbcontent" rows="7" class="form-control" required />
                            </div>
                        </div>

                        <div class="my-3 row justify-content-between mx-auto col-12 p-0">
                            <h3 class="col-12 text-left p-0 mb-3">Category </h3>
                            <asp:CheckBoxList runat="server" ID="cblCat" RepeatColumns="3" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Graphics&Design">Graphics & Design</asp:ListItem>
                                <asp:ListItem Value="Writing&Translation">Writing & Translation</asp:ListItem>
                                <asp:ListItem Value="Video&Animation">Video & Animation</asp:ListItem>
                                <asp:ListItem Value="Music&Audio">Music & Audio</asp:ListItem>
                                <asp:ListItem Value="Programming&Tech">Programming & Tech</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <asp:LinkButton runat="server" ID="submitProj" CssClass="btn btn-success" OnClick="submitProj_Click">Add Project</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="<%=Page.ResolveUrl("~/Scripts/servicescript.js") %>" type="text/javascript"></script>
</asp:Content>
