package com.lg;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "UsersGroup")
public class UsersGroup {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;

    @ManyToMany(mappedBy = "groups", cascade = CascadeType.ALL)
    private Set<User> users = new HashSet<>();

    public UsersGroup() {
    }

    public UsersGroup(Long id, String name) {
        this.id = id;
        this.name = name;
    }

    public void addUser(User user) {
        this.users.add(user);
        user.getGroups().add(this);
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Set<User> getUsers() {
        return users;
    }

    public void setUsers(Set<User> users) {
        this.users = users;
    }
}