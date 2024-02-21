/// <reference types="Cypress" />

describe('template spec', () => {
  beforeEach(function() {
    cy.visit('http://localhost:3000/')
  })

  it('Check Home', () => {
    cy.get('.home__container > h1').should(($p) => expect($p).to.contain("Sistema Open Finance"))
  })

  it('Check Open Banking', () => {
    cy.get('#item-2').click()
    cy.get('.view__area > :nth-child(1) > .text-3xl').should(($p) => expect($p).to.contain("Tabela Open Banking"))
  })
  
  it('Check Open Banking:Information', () => {
    cy.get('#item-2').click()
    cy.get('tbody > :nth-child(1) > :nth-child(2) > .p-2 > :nth-child(1)').click()
    
    cy.get(':nth-child(1) > :nth-child(2) > .p-2 > .opacity-100 > .bg-white > .px-4 > .border-cblue').should(($p) => expect($p).to.contain("Informações"))
    cy.get(':nth-child(1) > :nth-child(2) > .p-2 > .opacity-100 > .bg-white > .px-4 > .border-cblue').click()
  });

  it('Check Open Banking:Configuração', () => {
    cy.get('#item-2').click()

    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > :nth-child(1) > .icon__bt').click()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .border-cblue').should(($p) => expect($p).to.contain("Configurações"))
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .justify-end > button').click()
  });

  it('Check Open Banking:Favorite', () => {
    cy.get('#item-2').click()

    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > :nth-child(1) > .icon__bt').click()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .flex-row > .pl-3 > .mt-3 > .cursor-pointer').uncheck()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .flex-row > .pl-3 > .mt-3 > .cursor-pointer').check()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .justify-end > button').click()

    cy.get('tbody > :nth-child(1) > :nth-child(1) > div').should(($p) => expect($p).to.contain("⭐"))
    
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > :nth-child(1) > .icon__bt').click()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .flex-row > .pl-3 > .mt-3 > .cursor-pointer').uncheck()
    cy.get(':nth-child(1) > :nth-child(5) > .p-2 > .opacity-100 > .bg-white > .px-4 > .justify-end > button').click()

    cy.get('tbody > :nth-child(1) > :nth-child(1) > div').should(($p) => expect($p).to.not.contain("⭐"))
  });

  it('Check Configuração', () => {
    cy.get('#item-3').click()
    cy.get('.view__area > :nth-child(1) > .text-3xl').should(($p) => expect($p).to.contain("Configurações do sistema"))
  });

  it('Check Sobre', () => {
    cy.get('#item-4').click()
    cy.get('#title-sobre').should(($p) => expect($p).to.contain("Sobre o Open Finance"))
  });
})