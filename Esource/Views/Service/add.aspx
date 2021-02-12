<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Esource.Views.service.add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="addservice">
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="container">
            <div class="card card-body">
                <h3 class="text-info font-weight-bold">Add Service</h3>
                <div class="row">
                    <div class="col-lg-8">
                        <div class="md-form md-outline">
                            <asp:Label runat="server" AssociatedControlID="tbName" Text="Service name"></asp:Label>
                            <asp:TextBox runat="server" ID="tbName" CssClass="form-control w-50"></asp:TextBox>
                        </div>

                        <div class="md-form md-outline">
                            <asp:Label runat="server" AssociatedControlID="tbDesc" Text="Service description"></asp:Label>
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbDesc" CssClass="form-control" Rows="7"></asp:TextBox>
                        </div>

                        <div class="md-form md-outline">
                            <asp:Label runat="server" AssociatedControlID="tbPrice" Text="Price ($)"></asp:Label>
                            <asp:TextBox runat="server" TextMode="Number" ID="tbPrice" CssClass="form-control w-25"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <label class="font-italic">Service poster (Optional)</label>
                        <div class="filepreview">
                            <div class="wrapper card card-body view overlay text-center z-depth-2">
                                <div class="mask rgba-black-slight"></div>
                                <div class="preview deep-purple accent-3">
                                    <img src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>" id="poster" />
                                    <div id="fileMask" class="infos d-none">
                                        <div class="infos-inner">
                                            <p id="maskText" class="filename"></p>
                                            <a class="btn btn-sm btn-success">Change image</a>
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
                            <a id="fileRemove" class="btn btn-danger btn-sm text-center d-none" style="z-index: 3;">Remove image</a>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-lg-9">
                            <label class="font-italic">Category(s)</label>
                            <br />
                            <asp:CheckBoxList runat="server" ID="cblCat" RepeatColumns="3" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Graphics&Design">Graphics & Design</asp:ListItem>
                                <asp:ListItem Value="Writing&Translation">Writing & Translation</asp:ListItem>
                                <asp:ListItem Value="Video&Animation">Video & Animation</asp:ListItem>
                                <asp:ListItem Value="Music&Audio">Music & Audio</asp:ListItem>
                                <asp:ListItem Value="Programming&Tech">Programming & Tech</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <br />
                <div>
                    <a href="<%=Page.ResolveUrl("~/Views/service/manage.aspx") %>" class="btn btn-danger">Cancel</a>
                    <asp:Button runat="server" ID="btnAdd" Text="Add Service" CssClass="btn btn-success" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </section>
    <script src="<%=Page.ResolveUrl("~/Scripts/servicescript.js") %>" type="text/javascript"></script>
</asp:Content>
