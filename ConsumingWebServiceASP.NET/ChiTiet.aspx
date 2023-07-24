<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ChiTiet.aspx.cs"
    Inherits="ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
                <div class="page-title-right">
                    <%= DateTime.Now.ToShortDateString() %>
                </div>
                <p class="page-title font-15">
                    <ol class="breadcrumb m-0">
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Hyper</a></li>
                        <li class="breadcrumb-item"><a href="javascript: void(0);">Pages</a></li>
                        <li class="breadcrumb-item active">Starter</li>
                    </ol>
                </p>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div class="page-title-box">
               <asp:DataList ID="ChiTietNoiDung" runat="server">
                <ItemTemplate>
                     <h2><%# Eval("tieude") %>
                        <%--tieude--%>
                </h2>
                <div class="detail-line-top d-flex justify-content-between">
                   <div class="detail-article-date">
                        <span> <%# Eval("ngaydang","{0:dd/M/yyyy H:mm:ss}") %></span>
                
                    </div>
                    <div class="detail-share-top ">
                        <div>   
                            Lượt xem:  <%# Eval("luotxem") %>
                        </div>
                    </div>
                </div>
                      <p class="font-20">
                    <em>
                        <%--tomtat--%>
                           <%# Eval("tomtat") %></em>
                </p>
                <div class="content-news">
                    <p
                        style="margin: 0px 0px 10px; color: rgb(68, 68, 68); line-height: 26px; font-family: Arial; font-size: 16px; background-color: rgb(255, 255, 255); text-align: justify">
                        <%# Eval("NoiDung") %>
                    </p>
                   
                    <%--noidung--%>
                </div>
                </ItemTemplate>
            </asp:DataList>
               
              
                <div class="row mt-3">   
                    <div class="col">
                        <h5 class="mb-2 font-16">Comments</h5>

                        <div class="media mt-3 p-1">
                            <img src="assets/images/users/avatar-9.jpg" class="mr-2 rounded-circle" height="36"
                                alt="Arya Stark">
                            <div class="media-body">
                                <h5 class="mt-0 mb-0">
                                    <span class="float-right text-muted font-12">4:30am</span>
                                    Arya Stark
                                </h5>
                                <p class="mt-1 mb-0 text-muted">
                                    Should I review the last 3 years legal documents as well?
                                </p>
                            </div>
                        </div>
                        <!-- end comment -->

                        <hr>

                        <div class="media mt-2 p-1">
                            <img src="assets/images/users/avatar-5.jpg" class="mr-2 rounded-circle" height="36"
                                alt="Dominc B">
                            <div class="media-body">
                                <h5 class="mt-0 mb-0">
                                    <span class="float-right text-muted font-12">3:30am</span>
                                    Gary Somya
                                </h5>
                                <p class="mt-1 mb-0 text-muted">
                                    @Arya FYI..I have created some general guidelines last year.
                                </p>
                            </div>
                        </div>
                        <!-- end comment-->

                        <hr>
                    </div>
                    <!-- end col -->
                </div>
                <div class="row mt-2">
                    <div class="col">
                        <div class="border rounded">
                            <form action="#" class="comment-area-box">
                                <textarea rows="3" class="form-control border-0 resize-none"
                                    placeholder="Your comment..."></textarea>
                                <div class="p-2 bg-light">
                                    <div class="float-right">
                                        <button type="submit" class="btn btn-sm btn-success">
                                            <i
                                                class="uil uil-message mr-1"></i>Submit</button>
                                    </div>
                                    <div>
                                        <a href="#" class="btn btn-sm px-1 btn-light"><i
                                            class="uil uil-cloud-upload"></i></a>
                                        <a href="#" class="btn btn-sm px-1 btn-light"><i class="uil uil-at"></i></a>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <!-- end .border-->
                    </div>
                    <!-- end col-->
                </div>
                <!-- tin liên quan  -->
                <h4 class="header-title mt-3 font-weight-bolder font-24 font-italic badge badge-danger">Tin liên
                        quan</h4>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Tin mới nhất -->
                <h4 class="header-title mt-3 font-weight-bolder font-24 font-italic badge badge-primary">Tin mới
                        nhất
                </h4>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mb-0 mt-2">
                    <div class="card-body">
                        <div class="media">
                            <a href="">
                                <img src="assets/images/users/avatar-2.jpg" alt="image"
                                    class="mr-3 d-none d-sm-block avatar"></a>
                            <div class="media-body">
                                <a href="#" class="mb-1 mt-0 text-dark">Bị cục nóng điều hòa từ tầng 17 rơi
                                        trúng đầu, nữ
                                        sinh tử
                                        vong</a>
                                <div class="mt-2">
                                    <a href="#">Thời sự</a> <span>- 2 Giờ trước</span>
                                </div>
                                <div class="mb-0 mt-2 text-muted">
                                    <span class="font-italic"><b>"</b>Một nữ sinh viên 21 tuổi ở
                                            Đài Loan chết
                                            oan uổng khi đang đứng chờ xe buýt do bị cục nóng điều hòa nặng 30kg từ
                                            tầng 17 tòa nhà cạnh đó rơi trúng đầu.</span><b>"</b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
